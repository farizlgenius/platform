using Identity.Application.DTOs;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IOperatorRepository : IBaseRepository<OperatorDto,Operator>
    {
        Task<OperatorDto> GetByUsernameAsync(string Username);
        Task<string> GetPasswordByUsernameAsync(string Username);
        Task<int> UpdatePasswordAsync(string username, string password);
        Task<bool> IsAnyByUsernameAsync(string Username);

    }
}
