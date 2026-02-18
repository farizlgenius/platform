using Identity.Application.DTOs;
using Identity.Application.Settings;
using Identity.Domain.Entities;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Identity.Application.Entities;

namespace Identity.Application.Services
{
    public sealed class AuthService(IOptions<JwtSetting> settings,IOperatorRepository oper,IRoleRepository rol,ITokenRepository token) : IAuth
    {

        private readonly string _secret = settings.Value.Secret;
        private readonly string _issuer = settings.Value.Issuer;
        private readonly string _audience = settings.Value.Audience;
        private readonly int _minutes = settings.Value.AccessTokenMinutes;
        private readonly TimeSpan _refreshTtl = TimeSpan.FromHours(3);


        private readonly JsonSerializerOptions jopts = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public bool ValidateLogin(string StoreHashed, string Password)
        {
            return EncryptHelper.VerifyPassword(Password, StoreHashed);
        }

        public async Task<Response<Token>> LoginAsync(LoginDto model, string ip)
        {

            var user = await oper.GetByUsernameAsync(model.Username);
            var hash = await oper.GetPasswordByUsernameAsync(model.Username);

            if (user is null) return ResponseHelper.NotFoundBuilder<Token>(["User not found."]);

            var role = await rol.GetByIdAsync((short)user.role.Id);



            // TODO: Replace with real user validation (DB, hashed passwords)
            if (!ValidateLogin(hash, model.Password))
                return ResponseHelper.Unauthorize<Token>(["password incorrect."]);

            var accessToken = CreateAccessToken(user, role);

            // create random refresh token and store hashed in redis + audit in DB
            var rawRefresh = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            await StoreTokenAsync(rawRefresh, user.UserId, user.Username, _refreshTtl, info: ip);

            var dto = new Token
            {
                TimeStamp = DateTime.UtcNow,
                AccessToken = accessToken,
                RefreshToken = rawRefresh,
                ExpireInMinute = (int)_refreshTtl.TotalMinutes
            };

            return ResponseHelper.SuccessBuilder<Token>(dto);
        }


        public async Task<Response<Token>> RefreshAsync(string oldRaw, string ip)
        {



            var rec = await GetByRawTokenAsync(oldRaw);

            if (rec == null || rec.ExpireAt < DateTime.UtcNow)
            {
                // token invalid expire
                if (rec != null) await RevokeTokenAsync(oldRaw);
                return ResponseHelper.Unauthorize<Token>(["Invalid refresh token"]);
            }

            var user = await oper.GetByUsernameAsync(rec.Username);
            var role = await rol.GetByIdAsync(user.role.Id);

            if (user is null) return ResponseHelper.NotFoundBuilder<Token>(["User not found."]);

            if (String.IsNullOrEmpty(user.Username)) return ResponseHelper.NotFoundBuilder<Token>(["Can not automatic create token username with specific userid not found"]);

            // rotate token automatically: create new raw token and swap in redis
            var newRaw = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            try
            {
                await RotateTokenAtomicAsync(oldRaw, newRaw, rec.UserId, rec.Username, _refreshTtl, ip);
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.Unauthorize<Token>(["Token reuse detected"]);
            }



            // issue new access token
            var accessToken = CreateAccessToken(user, role);


            var dto = new Token
            {
                AccessToken = accessToken,
                TimeStamp = DateTime.UtcNow,
                RefreshToken = newRaw,
                ExpireInMinute = (int)_refreshTtl.TotalMinutes
            };
            return ResponseHelper.SuccessBuilder<Token>(dto);

        }

        public async Task<Response<bool>> RevokeAsync(string rawToken)
        {


            await RevokeTokenAsync(rawToken);

            return ResponseHelper.SuccessBuilder<bool>(true);
        }


        public string CreateAccessToken(OperatorDto user, RoleDto role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var users = new
            {
                Title = user.Title ?? "",
                Firstname = user.Firstname ?? "",
                Middlename = user.Middlename ?? "",
                Lastname = user.Lastname ?? "",
                Email = user.Email ?? "",
            };
            var locations = user.LocationIds;
            var roles = new
            {
                Id = role.Id,
                Name = role.Name,
                Features = role.Features.Select(x => x.Id).ToList()
            };


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role, role.Name),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                // Custom Claims
                new Claim("user",JsonSerializer.Serialize(users)),
                new Claim("location",JsonSerializer.Serialize(locations)),
                new Claim("rol",JsonSerializer.Serialize(roles))
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_minutes),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task StoreTokenAsync(string rawToken, string userId, string username, TimeSpan ttl, string? info = null)
        {
            var hashed = EncryptHelper.Hash(rawToken);

            // write audit row
            var status = await token.AddRefreshTokenAsync(hashed, userId, username, "", ttl);
            if (status <= 0) throw new Exception("Can't Save new refresh token to database.");
        }

        public async Task<RefreshToken> GetByRawTokenAsync(string rawToken)
        {
            var hashed = EncryptHelper.Hash(rawToken);
            var refresh = await token.GetRefreshTokenByHashed(hashed);

            if (refresh is null) return null;
            if (refresh.Action.Equals("revoke")) return null;

            var userId = refresh.UserId;
            var userName = refresh.UserName;
            var expiresAt = refresh.ExpireDate;
            return new RefreshToken(hashed, userId, userName, expiresAt);

        }

        public async Task RotateTokenAtomicAsync(string oldRawToken, string newRawToken, string userId, string username, TimeSpan ttl, string? info = null)
        {
            var newHashed = EncryptHelper.Hash(newRawToken);

            // audit rotation in DB
            var status = await token.RotateRefreshTokenAsync(newHashed, userId, username, "", ttl);
            if (status <= 0) throw new Exception("Save new refresh token to database unsucccess.");
        }

        public async Task RevokeTokenAsync(string rawToken)
        {
            var hashed = EncryptHelper.Hash(rawToken);

            // audit rotation in DB
            var status = await token.RevokeTokenAsync(hashed);
            if (status <= 0) throw new Exception("Revoke token unsuccess.");
        }
    
    }
}
