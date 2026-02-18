using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class WeakPassword
    {
        [Key]
        public int id { get; set; }
        public string pattern { get; set; } = string.Empty;
        public int rule_id { get; set; }
        public PasswordRule password_rule { get; set; }
    }
}
