using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.Interfaces
{
    public interface IPagination<T>
    {
        IEnumerable<T> Data { get; set; }
        IPaginationData Page { get; set; }

    }
}
