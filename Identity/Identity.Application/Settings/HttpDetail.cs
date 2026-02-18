using Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Settings
{
    public class HttpDetail 
    {
        public string Url { get; set; } = string.Empty;

        public HttpEndpoint Endpoint { get; set; }
    }
}
