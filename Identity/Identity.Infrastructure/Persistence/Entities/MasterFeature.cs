using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class MasterFeature : BaseEntity
    {
        public string name { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;
    }
}
