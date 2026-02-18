

namespace Location.Application.Interfaces
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
