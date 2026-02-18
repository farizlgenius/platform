using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Infrastructure.Persistence.Entities
{
    public sealed class OperatorLocation : BaseEntity
    {
        public int location_id { get; set; }
        public Locations location { get; set; }
        public int operator_id { get; set; }

    }
}
