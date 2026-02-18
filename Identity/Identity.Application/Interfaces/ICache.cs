using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ICache
    {
        Task SetAsync(string key, string value, TimeSpan expiry);
        Task<string?> GetAsync(string key);
        Task<bool> ExistsAsync(string key);
    }
}
