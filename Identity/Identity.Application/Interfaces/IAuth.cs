using Identity.Application.DTOs;
using Identity.Application.Entities;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IAuth
    {
        Task<Response<Token>> LoginAsync(LoginDto login, string ip);
        Task<Response<Token>> RefreshAsync(string oldRaw, string ip);
        Task<Response<bool>> RevokeAsync(string token);
        bool ValidateLogin(string hashed, string Password);
        public string CreateAccessToken(OperatorDto user, RoleDto role);
        Task StoreTokenAsync(string rawToken, string userId, string username, TimeSpan ttl, string? info = null);
        Task<RefreshToken> GetByRawTokenAsync(string rawToken);
        Task RotateTokenAtomicAsync(string oldRawToken, string newRawToken, string userId, string username, TimeSpan ttl, string? info = null);
        Task RevokeTokenAsync(string rawToken);
    }
}
