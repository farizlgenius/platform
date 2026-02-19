using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public record FeatureDto(
        int Id,
        string Name,
        int ModuleId,
        bool IsAllow,
        bool IsCreate,
        bool IsModify,
        bool IsDelete,
        bool IsAction
        );
}
