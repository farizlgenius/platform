using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public sealed class Token
    {
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int ExpireInMinute { get; set; }
    }
}
