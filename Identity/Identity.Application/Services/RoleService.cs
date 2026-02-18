using Identity.Application.DTOs;
using Identity.Application.Entities;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public sealed class RoleService(IRoleRepository repo) : IRole
    {
        public async Task<Response<RoleDto>> CreateAsync(CreateRole dto)
        {
            if (await repo.IsAnyByNameAsync(dto.Name)) return ResponseHelper.Duplicate<RoleDto>();

            var features = new List<Feature>();
            foreach (var f in dto.Features) 
            {
                features.Add(new Feature(f.Name,f.Path,f.IsAllow,f.IsCreate,f.IsModify,f.IsDelete,f.IsAction));
            }
            var role = new Role(dto.Name,features,dto.Location);

            var status = await repo.AddAsync(role);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<RoleDto>(ResponseMessage.SAVE_DATABASE_UNSUCCESS, []);
            return ResponseHelper.SuccessBuilder<RoleDto>(await repo.GetByNameAsync(dto.Name));
        }

        public async Task<Response<RoleDto>> DeleteByIdAsync(int Id)
        {
            var en = await repo.GetByIdAsync(Id);

            if(en is null) return ResponseHelper.NotFoundBuilder<RoleDto>();

            if (await repo.IsAnyReferenceByIdAsync(Id)) return ResponseHelper.FoundReferenceBuilder<RoleDto>([ResponseMessage.FOUND_REFERENCE]);

            var status = await repo.DeleteByIdAsync(Id);
            if(status == -1) return ResponseHelper.NotFoundBuilder<RoleDto>();
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<RoleDto>(ResponseMessage.DELETE_DATABASE_UNSUCCESS, []);

            return ResponseHelper.SuccessBuilder<RoleDto>(en);
        }

        public async Task<Response<IEnumerable<RoleDto>>> DeleteRangeAsync(IdList dtos)
        {
            bool flag = true;
            List<RoleDto> data = new List<RoleDto>();
            foreach (var dto in dtos.Ids)
            {
                var re = await DeleteByIdAsync(dto);
                if (re.Code != HttpStatusCode.OK) flag = false;
                if (re.Data is not null) data.Add(re.Data);
            }

            if (!flag) return ResponseHelper.UnsuccessBuilder<IEnumerable<RoleDto>>(data);

            var res = ResponseHelper.SuccessBuilder<IEnumerable<RoleDto>>(data);

            return res;
        }

        public async Task<Response<IEnumerable<RoleDto>>> GetAsync()
        {
            var dtos = await repo.GetAsync();
            return ResponseHelper.SuccessBuilder<IEnumerable<RoleDto>>(dtos);

        }

        public async Task<Response<RoleDto>> GetByComponentIdAsync(int Id)
        {
            var dto = await repo.GetByIdAsync(Id);

            return ResponseHelper.SuccessBuilder(dto);

        }

        public async Task<Response<RoleDto>> GetByIdAsync(int Id)
        {
            var res = await repo.GetByIdAsync(Id);
            return ResponseHelper.SuccessBuilder(res);
        }

        public async Task<Response<IEnumerable<RoleDto>>> GetByLocationAsync(int location)
        {
            var dto = await repo.GetByLocationIdAsync(location);

            return ResponseHelper.SuccessBuilder(dto);
        }

        public async Task<Response<Pagination<RoleDto>>> GetPaginationAsync(PaginationParam param, int location)
        {
            var res = await repo.GetPaginationAsync(param, location);
            return ResponseHelper.SuccessBuilder(res);
        }

        public async Task<Response<RoleDto>> UpdateAsync(UpdateRole dto)
        {
            if (!await repo.IsAnyById(dto.Id)) return ResponseHelper.NotFoundBuilder<RoleDto>();

            var role = new Role();

            var status = await repo.UpdateAsync(role);
            if (status == -1) return ResponseHelper.NotFoundBuilder<RoleDto>();
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<RoleDto>(ResponseMessage.UPDATE_RECORD_UNSUCCESS, []);

            return ResponseHelper.SuccessBuilder(await repo.GetByIdAsync(dto.Id));
        }
    }
}
