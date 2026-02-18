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
    public class RoleController(IRole service) : ControllerBase
    {
        [HttpGet]
        
        public async Task<ActionResult<Response<IEnumerable<RoleDto>>>> GetAsync()
        {
            var res = await service.GetAsync();
            return Ok(res);
        }

        [HttpGet("/api/{location}/[controller]")]
        
        public async Task<ActionResult<Response<IEnumerable<RoleDto>>>> GetByLocationIdAsync(short location)
        {
            var res = await service.GetByLocationAsync(location);
            return Ok(res);
        }

        [HttpGet("/api/{location}/[controller]/pagination")]
        
        public async Task<ActionResult<Response<Pagination<RoleDto>>>> GetPaginationAsync([FromQuery] PaginationParam param, short location)
        {
            var res = await service.GetPaginationAsync(param, location);
            return Ok(res);
        }

        [HttpPost]
        
        public async Task<ActionResult<Response<bool>>> CreateAsync([FromBody] CreateRole dto)
        {
            var res = await service.CreateAsync(dto);
            return Ok(res);
        }

        [HttpPost("delete/range")]
        
        public async Task<ActionResult<Response<IEnumerable<Response<bool>>>>> DeleteRangeAsync([FromBody] IdList dtos)
        {
            var res = await service.DeleteRangeAsync(dtos);
            return Ok(res);
        }

        [HttpPut]
        
        public async Task<ActionResult<Response<RoleDto>>> UpdateAsync([FromBody] UpdateRole dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpDelete("{Id}")]
        
        public async Task<ActionResult<Response<bool>>> DeleteByIdAsync(int Id)
        {
            var res = await service.DeleteByIdAsync(Id);
            return Ok(res);
        }

        [HttpGet("{Id}")]
        
        public async Task<ActionResult<Response<RoleDto>>> GetByIdAsync(int Id)
        {
            var res = await service.GetByIdAsync(Id);
            return Ok(res);
        }
    }
}
