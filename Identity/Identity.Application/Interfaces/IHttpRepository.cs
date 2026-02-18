using Identity.Application.DTOs;
using Identity.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IHttpRepository
    {
        Task<Response<IEnumerable<int>>> GetLocationIdsAsync();
        Task<Response<bool>> IsAnyByLocationIdListAsync(IdList ids);
    }
}
