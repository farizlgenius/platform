using Identity.Application.DTOs;
using Identity.Application.Entities;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController(IOperator service) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Response<Pagination<OperatorDto>>>> GetAsync()
        {
            var res = await service.GetAsync();
            return Ok(res);
        }

        [HttpGet("/api/v1/{location}/[controller]")]
        [Authorize]
        public async Task<ActionResult<Response<IEnumerable<OperatorDto>>>> GetByLocationAsync(short location)
        {
            var res = await service.GetByLocationAsync(location);
            return Ok(res);
        }

        [HttpGet("/api/v1/{location}/[controller]/pagination")]
        [Authorize]
        public async Task<ActionResult<Response<Pagination<OperatorDto>>>> GetPaginationAsync([FromQuery] PaginationParam param, short location)
        {
            var res = await service.GetPaginationAsync(param, location);
            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Response<bool>>> CreateAsync([FromBody] CreateOperator dto)
        {
            var res = await service.CreateAsync(dto);
            return Ok(res);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Response<OperatorDto>>> UpdateAsync([FromBody] UpdateOperator dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpDelete("{component}")]
        [Authorize]
        public async Task<ActionResult<Response<bool>>> DeleteByIdAsync(short component)
        {
            var res = await service.DeleteByIdAsync(component);
            return Ok(res);
        }

        [HttpPost("delete/range")]
        public async Task<ActionResult<Response<IEnumerable<Response<bool>>>>> DeleteRangeAsync([FromBody] IdList ids)
        {
            var res = await service.DeleteRangeAsync(ids);
            return Ok(res);
        }

        [HttpGet("{username}")]
        [Authorize]
        public async Task<ActionResult<Response<OperatorDto>>> GetByUsernameAsync(string username)
        {

            var res = await service.GetByUsernameAsync(username);
            return Ok(res);
        }

        [HttpPut("password/update")]
        [Authorize]
        public async Task<ActionResult<Response<bool>>> UpdatePasswordAsync(ChangePasswordDto dto)
        {
            var res = await service.UpdatePasswordAsync(dto);
            return Ok(res);
        }
    }
}
