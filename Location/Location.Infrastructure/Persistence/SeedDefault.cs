using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Infrastructure.Persistence
{
    public sealed class SeedDefaults
    {
        //public static readonly DateTime SystemDate = new DateTime(2025, 01, 01);
        public static readonly DateTime SystemDate = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc);

    }
}
