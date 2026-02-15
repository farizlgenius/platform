using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public sealed class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsAllow { get; set; }
        public bool IsCreate { get; set; }
        public bool IsModify { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAction { get; set; }
    }
}
