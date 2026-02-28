using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record RequestExitDto(
        short ModuleId,
        short InputNom,
        short InputMode,
        short Debounce,
        short HoldTime,
        short MaskTimeZone
        );
}
