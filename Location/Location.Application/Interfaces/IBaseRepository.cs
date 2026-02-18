
using Location.Application.Entities;
using Location.Domain.Entities;

namespace Location.Application.Interfaces
{
    public interface IBaseRepository<T,Y>
    {
        Task<bool> IsAnyById(int component);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int componentId);
        Task<Pagination<T>> GetPaginationAsync(PaginationParam param);
        Task<int> AddAsync(Y data);
        Task<int> DeleteByIdAsync(int component);
        Task<int> UpdateAsync(Y data);
    }
}
