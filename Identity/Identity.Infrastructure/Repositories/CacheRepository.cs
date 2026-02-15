using Identity.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    public class CacheRepository : ICache
    {
        private readonly IDatabase _db;

        public CacheRepository(IConfiguration config)
        {
            var redis = ConnectionMultiplexer.Connect(
            config["Redis:Connection"]!);

            _db = redis.GetDatabase();
        }
        public async Task SetAsync(string key, string value, TimeSpan expiry)
        {
            await _db.StringSetAsync(key, value, expiry);
        }

        public async Task<string?> GetAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            return await _db.KeyExistsAsync(key);
        }
    }
}
