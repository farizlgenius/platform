using Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Entities
{
    public sealed class PaginationData : IPaginationData
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }
    }
}
