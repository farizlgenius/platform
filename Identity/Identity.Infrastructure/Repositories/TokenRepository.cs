using Identity.Domain.Entities;
using Identity.Domain.Interfaces;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    public sealed class TokenRepository(AppDbContext context) : ITokenRepository
    {
        public async Task<int> AddRefreshTokenAsync(string hashed, string userId, string username, string info, TimeSpan ttl)
        {
            // write audit row
            var audit = new Identity.Infrastructure.Persistence.Entities.RefreshTokenAudit
            {
                hashed_token = hashed,
                userid = userId,
                username = username,
                action = "create",
                info = info,
                created_date = DateTime.UtcNow,
                updated_date = DateTime.UtcNow,
                expire_date = DateTime.UtcNow.Add(ttl)
            };
            await context.refresh_token.AddAsync(audit);
            return await context.SaveChangesAsync();
        }

        public async Task<Domain.Entities.RefreshTokenAudit> GetRefreshTokenByHashed(string hashed)
        {
            var refresh = await context.refresh_token
                .AsNoTracking()
                .Where(x => x.hashed_token.Equals(hashed))
                .FirstOrDefaultAsync();

            if (refresh is null) return null;

            return new Domain.Entities.RefreshTokenAudit
            {
                HashedToken = refresh.hashed_token,
                UserId = refresh.userid,
                UserName = refresh.username,
                Action = refresh.action,
                Info = refresh.info,
                ExpireDate = refresh.expire_date,
                CreatedDate = refresh.created_date,
                UpdatedDate = refresh.updated_date,
            };
        }

        public async Task<int> RevokeTokenAsync(string hashed)
        {
            var data = new Identity.Infrastructure.Persistence.Entities.RefreshTokenAudit
            {
                hashed_token = hashed,
                userid = "unknown",
                username = "unknown",
                action = "revoke",
                created_date = DateTime.UtcNow,

            };
            await context.refresh_token.AddAsync(data);
            return await context.SaveChangesAsync();
        }

        public async Task<int> RotateRefreshTokenAsync(string hashed, string userId, string username, string info, TimeSpan ttl)
        {
            var data = new Identity.Infrastructure.Persistence.Entities.RefreshTokenAudit
            {
                hashed_token = hashed,
                userid = userId,
                username = username,
                action = "rotate",
                info = info,
                created_date = DateTime.UtcNow,
                expire_date = DateTime.UtcNow.Add(ttl),
                updated_date = DateTime.UtcNow

            };
            await context.refresh_token.AddAsync(data);
            return await context.SaveChangesAsync();
        }
    }
}
