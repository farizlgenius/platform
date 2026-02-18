using Location.Application.DTOs;
using Location.Application.Entities;
using Location.Domain.Entities;


namespace Location.Application.Interfaces
{
    public interface ILocationRepository : IBaseRepository<LocationDto,Locations>
    {
        Task<bool> IsAnyByNameAsync(string name);
        Task<LocationDto> GetByNameAsync(string name);
        Task<int> CountAsync();
        Task<IEnumerable<string>> CheckReferenceByIdAsync(int id);
        Task<IEnumerable<LocationDto>> GetLocationListByIdsAsync(IdList ids);
        Task<IdList> GetIdsAsync();
        Task<bool> IsAnyLocationIdAsync(int id);
    }
}
