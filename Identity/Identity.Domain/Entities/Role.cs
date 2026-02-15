using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public sealed class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Feature> Features { get; set; } = new List<Feature>();
    }
}
