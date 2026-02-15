using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> IsAnyById(int component);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int componentId);
        Task<IEnumerable<T>> GetByLocationIdAsync(int locationId);
        Task<Pagination<T>> GetPaginationAsync(PaginationParam param, int location);
        Task<int> AddAsync(T data);
        Task<int> DeleteByIdAsync(int component);
        Task<int> UpdateAsync(T newData);
    }
}
