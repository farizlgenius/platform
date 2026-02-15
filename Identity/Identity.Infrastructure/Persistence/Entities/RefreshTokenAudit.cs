using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class RefreshTokenAudit
    {
        [Key]
        public int id { get; set; }
        public string hashed_token { get; set; } = default!; // store hashed token
        public string userid { get; set; } = default!;
        public string username { get; set; } = default!;
        public string action { get; set; } = default!; // "create", "rotate", "revoke"
        public string? info { get; set; } // optional JSON for ip/user-agent
        public DateTime expire_date { get; set; } = DateTime.UtcNow;
        public DateTime created_date { get; set; } = DateTime.UtcNow;
        public DateTime updated_date { get; set; } = DateTime.UtcNow;

    }
}
