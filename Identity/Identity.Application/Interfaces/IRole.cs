using Identity.Application.DTOs;
using Identity.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IRole
    {
        Task<Response<RoleDto>> CreateAsync(CreateRole dto);
        Task<Response<RoleDto>> DeleteByIdAsync(int Id);
        Task<Response<IEnumerable<RoleDto>>> DeleteRangeAsync(IdList dtos);
        Task<Response<IEnumerable<RoleDto>>> GetAsync();
        Task<Response<IEnumerable<RoleDto>>> GetByLocationAsync(int location);
        Task<Response<RoleDto>> GetByIdAsync(int Id);
        Task<Response<RoleDto>> UpdateAsync(UpdateRole dto);
        Task<Response<Pagination<RoleDto>>> GetPaginationAsync(PaginationParam param, int location);
    }
}
