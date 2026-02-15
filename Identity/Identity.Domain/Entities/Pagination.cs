using Identity.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public class Pagination<T> : IPagination<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public IPaginationData? Page { get; set; }
    }
}
