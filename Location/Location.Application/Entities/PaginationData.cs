

using Location.Application.Interfaces;

namespace Location.Application.Entities
{
    public sealed class PaginationData : IPaginationData
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }
    }
}
