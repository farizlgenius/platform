using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ITokenRepository
    {
        Task<int> RevokeTokenAsync(string hashed);
        Task<RefreshTokenAudit> GetRefreshTokenByHashed(string hashed);
        Task<int> AddRefreshTokenAsync(string hased, string userId, string username, string info, TimeSpan ttl);
        Task<int> RotateRefreshTokenAsync(string hashed, string userId, string username, string info, TimeSpan ttl);
    }
}
