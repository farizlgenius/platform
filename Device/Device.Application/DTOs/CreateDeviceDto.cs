using Device.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record CreateDeviceDto(string Name,DeviceType type,object Metadata,DateTime LastSync);    
    
}
