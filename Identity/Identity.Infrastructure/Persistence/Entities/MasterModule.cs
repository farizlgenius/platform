using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Entities
{
    public sealed class MasterModule : BaseEntity
    {
        public string name { get; set; } = string.Empty;
        public string desciption { get; set; } = string.Empty;
        public ICollection<MasterFeature> master_features { get; set; }

    }
}
