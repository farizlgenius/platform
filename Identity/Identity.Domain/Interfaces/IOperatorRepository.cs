using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
        Task<Operator> GetByUsernameAsync(string Username);
        Task<string> GetPasswordByUsernameAsync(string Username);
    }
}
