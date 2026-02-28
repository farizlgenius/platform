using Device.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record UpdateDeviceDtopublic(int Id, string Name, DeviceType Type, object Metadata, DateTime LastSync);
}
