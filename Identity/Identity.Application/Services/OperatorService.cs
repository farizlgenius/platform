using Identity.Application.DTOs;
using Identity.Application.Entities;
using Identity.Application.Helpers;
using Identity.Application.Interfaces;
using Identity.Domain.Constants;
using Identity.Domain.Entities;
using Identity.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public sealed class OperatorService(IOperatorRepository repo,IHttpRepository http,IMessagePublisher publisher) : IOperator
    {
        public async Task<Response<OperatorDto>> CreateAsync(CreateOperator dto)
        {
            if (string.IsNullOrEmpty(dto.Password)) return ResponseHelper.UnsuccessBuilder<OperatorDto>(ResponseMessage.PASSWORD_UNASSIGN, []);
            if (await repo.IsAnyByUsernameAsync(dto.Username)) return ResponseHelper.Duplicate<OperatorDto>();

            var ids = new IdList(dto.LocationIds);
            var res = await http.IsAnyByLocationIdListAsync(ids);

            if (!res.Data) throw new ArgumentException("Location id invalid.");

            var oper = new Operator(dto.UserId,dto.Username,dto.Password,dto.Email,dto.Title,dto.Firstname,dto.Middlename,dto.Lastname,dto.Phone,dto.Image,dto.RoleId,dto.LocationIds);
            

            var status = await repo.AddAsync(oper);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<OperatorDto>(ResponseMessage.SAVE_DATABASE_UNSUCCESS, []);

            // Trigger to adding location to operator
            var result = await repo.GetByUsernameAsync(dto.Username);
            var op = new OperatorCreatedEvent(result.Id, result.LocationIds);
            await publisher.PublishAsync(op);

            return ResponseHelper.SuccessBuilder<OperatorDto>(result);
        }

        public async Task<Response<OperatorDto>> DeleteByIdAsync(int id)
        {
            var en = await repo.GetByIdAsync(id);
            if (en is null) return ResponseHelper.NotFoundBuilder<OperatorDto>();

            var status = await repo.DeleteByIdAsync(id);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<OperatorDto>(ResponseMessage.DELETE_DATABASE_UNSUCCESS, []);

            return ResponseHelper.SuccessBuilder<OperatorDto>(en);
        }

        public async Task<Response<IEnumerable<OperatorDto>>> DeleteRangeAsync(IdList dtos)
        {
            bool flag = true;
            List<OperatorDto> data = new List<OperatorDto>();
            foreach (var id in dtos.Ids)
            {
                var re = await DeleteByIdAsync(id);
                if (re.Code != HttpStatusCode.OK) flag = false;
                if(re.Data is not null) data.Add(re.Data);
            }

            if (!flag) return ResponseHelper.UnsuccessBuilder<IEnumerable<OperatorDto>>(data);

            var res = ResponseHelper.SuccessBuilder<IEnumerable<OperatorDto>>(data);

            return res;
        }

        public async Task<Response<IEnumerable<OperatorDto>>> GetAsync()
        {
            var dto = await repo.GetAsync();
            return ResponseHelper.SuccessBuilder<IEnumerable<OperatorDto>>(dto);
        }

        public async Task<Response<IEnumerable<OperatorDto>>> GetByLocationAsync(int location)
        {
            var dto = await repo.GetByLocationIdAsync(location);
            return ResponseHelper.SuccessBuilder<IEnumerable<OperatorDto>>(dto);
        }

        public async Task<Response<OperatorDto>> GetByUsernameAsync(string username)
        {
            var dto = await repo.GetByUsernameAsync(username);

            return ResponseHelper.SuccessBuilder<OperatorDto>(dto);
        }

        public async Task<Response<Pagination<OperatorDto>>> GetPaginationAsync(PaginationParam param, int location)
        {
            var dtos = await repo.GetPaginationAsync(param, location);
            return ResponseHelper.SuccessBuilder<Pagination<OperatorDto>>(dtos);
        }

        public async Task<Response<OperatorDto>> UpdateAsync(UpdateOperator dto)
        {
            if (!await repo.IsAnyByUsernameAsync(dto.Username)) return ResponseHelper.NotFoundBuilder<OperatorDto>();


            var oper = new Operator(dto.UserId,dto.Username,"",dto.Email,dto.Title,dto.Firstname,dto.Middlename,dto.Lastname,dto.Phone,dto.Image,dto.RoleId,dto.LocationIds);

            var status = await repo.UpdateAsync(oper);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<OperatorDto>(ResponseMessage.UPDATE_RECORD_UNSUCCESS, []);

            var res = await repo.GetByUsernameAsync(dto.Username);

            return ResponseHelper.SuccessBuilder(res);
        }
        
        public async Task<Response<bool>> UpdatePasswordAsync(ChangePasswordDto dto)
        {
            if (!await repo.IsAnyByUsernameAsync(dto.Username)) return ResponseHelper.NotFoundBuilder<bool>();

            var pass = await repo.GetPasswordByUsernameAsync(dto.Username);

            if (!EncryptHelper.VerifyPassword(dto.Old, pass)) return ResponseHelper.UnsuccessBuilder<bool>(ResponseMessage.UNSUCCESS, [ResponseMessage.OLD_PASSPORT_INCORRECT]);

            var newPass = EncryptHelper.HashPassword(dto.New);

            var status = await repo.UpdatePasswordAsync(dto.Username, newPass);
            if (status <= 0) return ResponseHelper.UnsuccessBuilder<bool>(ResponseMessage.UPDATE_RECORD_UNSUCCESS, []);

            return ResponseHelper.SuccessBuilder<bool>(true);
        }
    }
}
