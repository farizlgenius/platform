using Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Settings
{
    public sealed class HttpEndpoint 
    {
        public string GetLocationId { get; set; } = string.Empty;

        public string IsAnyByLocationIdList { get; set; } = string.Empty;
    }
}
