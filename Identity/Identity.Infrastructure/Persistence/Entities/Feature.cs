using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class Feature : BaseEntity
    {
        public string name { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;
        public int role_id { get; set; }
        public Role role {get; set;}
        public bool is_allow { get; set; }
        public bool is_create { get; set; }
        public bool is_modify { get; set; }
        public bool is_delete { get; set; }
        public bool is_action { get; set; }

    }
}
