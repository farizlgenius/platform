using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IJwtSetting
    {
        string Secret { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        short AccessTokenMinutes { get; set; }
    }
}
