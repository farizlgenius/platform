

using Location.Application.Interfaces;

namespace Location.Application.Entities
{
    public sealed class Pagination<T> : IPagination<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IPaginationData Page { get; set; }
    }
}
