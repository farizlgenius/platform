using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record StrikeDto(
        short ModuleId,
        short OutputNo,
        short RelayMode,
        short OfflineMode,
        short StrkMax,
        short StrkMin,
        short StrkMode
        );
}
