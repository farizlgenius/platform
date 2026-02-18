using Location.Application.DTOs;
using Location.Application.Entities;
using Location.Application.Interfaces;
using Location.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Location.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocation loc) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<LocationDto>>>> GetAsync()
        {
            var res = await loc.GetAsync();
            return Ok(res);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Response<IdList>>> GetIdsAsycn()
        {
            var res = await loc.GetIdsAsync();
            return Ok(res);
        }

        [HttpPost("id")]
        public async Task<ActionResult<Response<bool>>> IsAnyLocationIdAsync([FromBody] IdList ids)
        {
            var res = await loc.IsAnyLocationIdAsync(ids);
            return Ok(res);
        }


        [HttpGet("pagination")]
        public async Task<ActionResult<Response<IEnumerable<LocationDto>>>> GetPaginationAsync([FromQuery] PaginationParam param)
        {
            var res = await loc.GetPaginationAsync(param);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Response<bool>>> CreateAsync([FromBody] CreateLocation req)
        {
            var res = await loc.CreateAsync(req);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<Response<LocationDto>>> UpdateAsync([FromBody] UpdateLocation dto)
        {
            var res = await loc.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> DeleteByIdAsync(short id)
        {
            var res = await loc.DeleteByIdAsync(id);
            return Ok(res);
        }

        [HttpPost("delete/range")]
        public async Task<ActionResult<Response<IEnumerable<Response<bool>>>>> DeleteRangeAsync([FromBody] IdList locationIds)
        {
            var res = await loc.DeleteRangeAsync(locationIds);
            return Ok(res);
        }

        [HttpPost("range")]
        public async Task<ActionResult<Response<IEnumerable<LocationDto>>>> GetRangeLocationById([FromBody] IdList locationIds)
        {
            var res = await loc.GetLocationListByIds(locationIds);
            return Ok(res);
        }

    }
}
