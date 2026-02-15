using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class Operator : BaseEntity
    {
        public required string userid { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
        public string email { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string middlename { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
        public int role_id { get; set; }
        public Role role { get; set; }
    }
}
