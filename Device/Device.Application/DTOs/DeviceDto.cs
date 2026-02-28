using Device.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record DeviceDto(
        int Id,
        int LocationId,
        bool IsActive,
        string Name,
        DeviceType Type,
        string TypeDetail,
        object Metadata,
        DateTime LastSync,
        List<ModuleDto> Modules
        );
}
