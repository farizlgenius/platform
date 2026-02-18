using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class PasswordRule
    {
        [Key]
        public int id { get; set; }
        public int len { get; set; }
        public bool is_lower { get; set; }
        public bool is_upper { get; set; }
        public bool is_digit { get; set; }
        public bool is_symbol { get; set; }
        public ICollection<WeakPassword> weak_passwords { get; set; }
    }
}
