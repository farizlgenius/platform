using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.Interfaces
{
    public interface IPaginationData
    {
        int TotalCount { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int TotalPage { get; }
    }
}
