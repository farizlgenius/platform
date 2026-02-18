using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class OperatorLocation 
    {
        [Key]
        public int id {  get; set; }
        public int location_id { get; set; }
        public Operator operators { get; set; }
        public int operator_id { get; set; }
        public DateTime created_date { get; set; } = DateTime.UtcNow;
        public DateTime updated_date { get; set; } = DateTime.UtcNow;
    }
}
