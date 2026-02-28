using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.Interfaces
{
    public interface IPaginationParam
    {
        int PageNumber { get; }
        int PageSize { get; }
        string Search { get; }
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
    }
}
