

namespace Location.Application.Interfaces
{
    public interface IPaginationData
    {
        int TotalCount { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int TotalPage { get; }
    }
}
