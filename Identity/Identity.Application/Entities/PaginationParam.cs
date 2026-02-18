using Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Entities
{
    public class PaginationParam : IPaginationParam
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Search { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
