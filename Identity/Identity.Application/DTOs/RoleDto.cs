using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public record RoleDto(int Id,string Name,IEnumerable<FeatureDto> Features);
}
