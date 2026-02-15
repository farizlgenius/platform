using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
        public long location_id { get; set; } = 0;
        public bool is_active { get; set; } = true;
        public DateTime created_date { get; set; } = DateTime.UtcNow;
        public DateTime updated_date { get; set; } = DateTime.UtcNow;
    }
}
