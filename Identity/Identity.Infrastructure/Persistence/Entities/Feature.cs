using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class Feature 
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;
        public int role_id { get; set; }
        public Role role {get; set;}
        public bool is_allow { get; set; }
        public bool is_create { get; set; }
        public bool is_modify { get; set; }
        public bool is_delete { get; set; }
        public bool is_action { get; set; }
        public bool is_active { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }

    }
}
