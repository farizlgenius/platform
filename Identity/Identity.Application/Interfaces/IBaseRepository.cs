using Identity.Application.Entities;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IBaseRepository<T,Y>
    {
        Task<bool> IsAnyById(int Id);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetByLocationIdAsync(int locationId);
        Task<Pagination<T>> GetPaginationAsync(PaginationParam param, int location);
        Task<int> AddAsync(Y data);
        Task<int> DeleteByIdAsync(int Id);
        Task<int> UpdateAsync(Y data);
    }
}
