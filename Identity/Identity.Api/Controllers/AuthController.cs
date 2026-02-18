using Identity.Application.DTOs;
using Identity.Domain.Entities;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;
using System.Text.Json;
using Identity.Application.Entities;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthController(IAuth service) : ControllerBase
    {
        private readonly TimeSpan _cookieExpiry = TimeSpan.FromHours(3);

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login([FromForm] LoginDto login)
        {
            var res = await service.LoginAsync(login, Request.HttpContext.Connection.RemoteIpAddress is null ? "" : Request.HttpContext.Connection.RemoteIpAddress.ToString());
            // set HttpOnly cookies (path limited to auth endpoint)
            if (res.Data is not null)
            {
                Response.Cookies.Append("refresh_token", res.Data.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    //SameSite = SameSiteMode.Strict,
                    SameSite = SameSiteMode.Lax,
                    Path = "/api/Auth",
                    Expires = DateTimeOffset.UtcNow.Add(_cookieExpiry)
                });
            }

            Console.WriteLine(res.Data.AccessToken);

            return Ok(new TokenDto 
            {
                TimeStamp = res.Timestamp,
                AccessToken = res.Data.AccessToken,
                RefreshToken = res.Data.RefreshToken,
                ExpireInMinute = res.Data.ExpireInMinute,
            });
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenDto>> Refresh([FromBody] Refresh? model)
        {
            // 1️⃣ Try get refresh token from body
            string? refreshToken = model?.refresh;

            // 2️⃣ If not in body, try cookie
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                Request.Cookies.TryGetValue("refresh_token", out refreshToken);
            }

            // 3️⃣ If still missing → unauthorized
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return Unauthorized();
            }

            // 4️⃣ Call service
            var res = await service.RefreshAsync(
                refreshToken,
                Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? ""
            );

            // 5️⃣ Set new refresh token cookie if issued
            if (res.Data is not null)
            {
                Response.Cookies.Append("refresh_token", res.Data.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.Lax,
                    Path = "/api/Auth",
                    Expires = DateTimeOffset.UtcNow.Add(_cookieExpiry)
                });
            }

            return Ok(res.Data);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Revoke([FromBody] Refresh? refresh)
        {
            // 1️⃣ Try body first
            string? refreshToken = refresh?.refresh;

            // 2️⃣ If not in body, try cookie
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                Request.Cookies.TryGetValue("refresh_token", out refreshToken);
            }

            // 3️⃣ If refresh token exists, revoke it
            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
                await service.RevokeAsync(refreshToken);

                Response.Cookies.Delete("refresh_token", new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.Lax,
                    Path = "/api/Auth",
                });
            }

            // 4️⃣ Always return OK if access token was valid
            return Ok(new { message = "Logged out successfully" });
        }

        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Exchange()
        {
            var request = HttpContext.GetOpenIddictServerRequest();

            // Client Credentials Flow
            if (request.IsClientCredentialsGrantType())
            {
                var identity = new ClaimsIdentity(
                    OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                identity.AddClaim(OpenIddictConstants.Claims.Subject, request.ClientId);
                identity.AddClaim(OpenIddictConstants.Claims.Scope, "api");

                var principal = new ClaimsPrincipal(identity);
                principal.SetScopes(request.GetScopes());

                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            // Authorization Code Flow
            if (request.IsAuthorizationCodeGrantType())
            {
                var result = await HttpContext.AuthenticateAsync(
                    OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                return SignIn(result.Principal!,
                    OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var userId = User.FindFirst("sub")?.Value ?? User.Identity?.Name ?? "unknown";
            var name = User.Identity?.Name;

            var userJson = User.FindFirst("user")?.Value ?? "";
            var user = string.IsNullOrEmpty(userJson) ? new Users
            {
                Title = "",
                Firstname = "",
                Middlename = "",
                Lastname = "",
                Email = ""
            } : JsonSerializer.Deserialize<Users>(userJson);

            var locJson = User.FindFirst("location")?.Value ?? "";
            var loc = string.IsNullOrEmpty(locJson) ? [] : JsonSerializer.Deserialize<List<short>>(locJson);
            var roleJson = User.FindFirst("rol")?.Value ?? "";
            var rol = string.IsNullOrEmpty(roleJson) ? new RoleDto(0, "", []): JsonSerializer.Deserialize<RoleDto>(roleJson);

            var info = new TokenInfo
            {
                User = user,
                Locations = loc,
                Role = rol
            };
            var dto = new TokenDetail
            {
                Auth = true,
                //info = info,
            };
            return Ok(
                new
                {
                    Auth = true,
                    User = new
                    {
                        Id = userId,
                        name,
                        Info = user,
                        Location = loc,
                        Role = rol
                    }
                }
                );
        }


    }

}

