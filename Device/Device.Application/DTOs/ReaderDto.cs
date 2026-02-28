using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record ReaderDto(
        short ModuleId,
        short ReaderNo,
        short DateFormat,
        short KeypadMode,
        short LedDriverMode,
        short Direction,
        bool OsdpFlag,
        short OsdpBaudrate,
        short OsdpDiscover,
        short OsdpTracing,
        short OsdpAddress,
        short OsdpSecureChannel
        );    
    
}
