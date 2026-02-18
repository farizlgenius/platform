using Identity.Application.DTOs;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IRoleRepository : IBaseRepository<RoleDto,Role>
    {
        Task<bool> IsAnyByNameAsync(string name);
        Task<bool> IsAnyReferenceByIdAsync(int id);
        Task<RoleDto> GetByNameAsync(string Name);

        
    }
}
