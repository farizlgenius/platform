using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Infrastructure.Persistance.Entities
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
        public int location_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_date { get; set; } = DateTime.UtcNow;
        public DateTime updated_date { get; set; } = DateTime.UtcNow;

        public BaseEntity(int location,bool status)
        {
            this.location_id = location;
            this.is_active = status;
        }
    }
}
