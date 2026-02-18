using Location.Application.DTOs;
using Location.Application.Entities;
using Location.Domain.Entities;

namespace Location.Application.Interfaces
{
    public interface ILocation
    {
        Task<Response<IEnumerable<LocationDto>>> GetAsync();
        Task<Response<Pagination<LocationDto>>> GetPaginationAsync(PaginationParam param);
        Task<Response<IdList>> GetIdsAsync();
        Task<Response<LocationDto>> GetByIdAsync(int id);
        Task<Response<LocationDto>> CreateAsync(CreateLocation dto);
        Task<Response<LocationDto>> DeleteByIdAsync(int id);
        Task<Response<IEnumerable<LocationDto>>> DeleteRangeAsync(IdList ids);
        Task<Response<LocationDto>> UpdateAsync(UpdateLocation dto);
        Task<Response<IEnumerable<LocationDto>>> GetLocationListByIds(IdList ids);
        Task<Response<bool>> IsAnyLocationIdAsync(IdList ids);
    }
}
