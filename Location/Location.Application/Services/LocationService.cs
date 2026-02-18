

using Location.Application.DTOs;
using Location.Application.Entities;
using Location.Application.Helpers;
using Location.Application.Interfaces;
using Location.Domain.Constants;
using Location.Domain.Entities;
using System.Net;

namespace Location.Application.Services
{
    public sealed class LocationService(ILocationRepository repo) : ILocation
    {
        // Get This from license service
        private readonly int LocationCount = 10;
        public async Task<Response<LocationDto>> CreateAsync(CreateLocation data)
        {
            if (await repo.IsAnyByNameAsync(data.Name.Trim())) return ResponseHelper.Duplicate<LocationDto>();

            if (await repo.CountAsync() == 10) return ResponseHelper.ExceedLimit<LocationDto>();

            var location = new Locations(data.Name, data.Description);

            var status = await repo.AddAsync(location);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<LocationDto>(ResponseMessage.SAVE_DATABASE_UNSUCCESS, []);
            return ResponseHelper.SuccessBuilder<LocationDto>(await repo.GetByNameAsync(data.Name));

        }

        public async Task<Response<LocationDto>> DeleteByIdAsync(int id)
        {
            if (id == 1) return ResponseHelper.DefaultRecord<LocationDto>();

            var en = await repo.GetByIdAsync(id);

            if (en is null) return ResponseHelper.NotFoundBuilder<LocationDto>();

            IEnumerable<string> errors = await repo.CheckReferenceByIdAsync(id);

            if (errors.Count() > 0) return ResponseHelper.FoundReferenceBuilder<LocationDto>(errors);

            var status = await repo.DeleteByIdAsync(id);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<LocationDto>(ResponseMessage.DELETE_DATABASE_UNSUCCESS, []);

            return ResponseHelper.SuccessBuilder<LocationDto>(en);
        }

        public async Task<Response<IEnumerable<LocationDto>>> DeleteRangeAsync(IdList ids)
        {
            bool flag = true;
            List<LocationDto> data = new List<LocationDto>();
            foreach (var id in ids.Ids)
            {
                var re = await DeleteByIdAsync(id);
                if (re.Code != HttpStatusCode.OK) flag = false;
                if(re.Data is not null) data.Add(re.Data);
            }

            if (!flag) return ResponseHelper.UnsuccessBuilder<IEnumerable<LocationDto>>(data);

            var res = ResponseHelper.SuccessBuilder<IEnumerable<LocationDto>>(data);

            return res;
        }


        public async Task<Response<IEnumerable<LocationDto>>> GetAsync()
        {
            var dto = await repo.GetAsync();
            return ResponseHelper.SuccessBuilder<IEnumerable<LocationDto>>(dto);
        }

        public async Task<Response<LocationDto>> GetByComponentIdAsync(short component)
        {
            var dto = await repo.GetByIdAsync(component);

            if (dto is null) return ResponseHelper.NotFoundBuilder<LocationDto>();

            return ResponseHelper.SuccessBuilder(dto);
        }

        public async Task<Response<LocationDto>> GetByIdAsync(int id)
        {
            var res = await repo.GetByIdAsync(id);
            return ResponseHelper.SuccessBuilder(res);
        }

        public async Task<Response<IdList>> GetIdsAsync()
        {
            var res = await repo.GetIdsAsync();
            return ResponseHelper.SuccessBuilder(res);
        }

        public async Task<Response<IEnumerable<LocationDto>>> GetLocationListByIds(IdList ids)
        {

            var dtos = await repo.GetLocationListByIdsAsync(ids);
            return ResponseHelper.SuccessBuilder<IEnumerable<LocationDto>>(dtos);
        }


        public async Task<Response<Pagination<LocationDto>>> GetPaginationAsync(PaginationParam param)
        {
            var dtos = await repo.GetPaginationAsync(param);
            return ResponseHelper.SuccessBuilder<Pagination<LocationDto>>(dtos);
        }

        public async Task<Response<bool>> IsAnyLocationIdAsync(IdList ids)
        {
            foreach (var id in ids.Ids) 
            {
                if (!await repo.IsAnyLocationIdAsync(id)) return ResponseHelper.SuccessBuilder<bool>(false);
            }
            return ResponseHelper.SuccessBuilder(true);
        }

        public async Task<Response<LocationDto>> UpdateAsync(UpdateLocation data)
        {
            if (data.Id == 1) return ResponseHelper.DefaultRecord<LocationDto>();

            var en = await repo.GetByIdAsync(data.Id);

            if (en is null) return ResponseHelper.NotFoundBuilder<LocationDto>();

            var location = new Locations(data.Name, data.Description);

            var status = await repo.UpdateAsync(location);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<LocationDto>(ResponseMessage.UPDATE_RECORD_UNSUCCESS, []);

            return ResponseHelper.SuccessBuilder<LocationDto>(await repo.GetByIdAsync(data.Id));
        }
    }
}
