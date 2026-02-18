using Identity.Application.DTOs;
using Identity.Application.Entities;

namespace Identity.Application.Interfaces
{
    public interface IOperator
    {
        Task<Response<IEnumerable<OperatorDto>>> GetAsync();
        Task<Response<IEnumerable<OperatorDto>>> GetByLocationAsync(int location);
        Task<Response<OperatorDto>> CreateAsync(CreateOperator dto);
        Task<Response<OperatorDto>> DeleteByIdAsync(int id);
        Task<Response<OperatorDto>> UpdateAsync(UpdateOperator dto);
        Task<Response<OperatorDto>> GetByUsernameAsync(string username);
        Task<Response<bool>> UpdatePasswordAsync(ChangePasswordDto dto);
        Task<Response<IEnumerable<OperatorDto>>> DeleteRangeAsync(IdList dtos);
        Task<Response<Pagination<OperatorDto>>> GetPaginationAsync(PaginationParam param, int location);
    }
}
