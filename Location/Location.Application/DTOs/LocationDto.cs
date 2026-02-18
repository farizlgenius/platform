using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Application.DTOs
{
    public record LocationDto(int Id,string Name,string Description,List<int> Operators);
}
