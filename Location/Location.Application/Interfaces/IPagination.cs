

namespace Location.Application.Interfaces
{
    public interface IPagination<T>
    {
        IEnumerable<T> Data { get; set; }
        IPaginationData Page { get; set; }

    }
}
