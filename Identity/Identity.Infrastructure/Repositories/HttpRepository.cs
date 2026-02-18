using Identity.Application.DTOs;
using Identity.Application.Entities;
using Identity.Application.Interfaces;
using Identity.Application.Settings;
using Identity.Domain.Constants;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Identity.Infrastructure.Repositories
{
    public sealed class HttpRepository(HttpClient http,IOptions<HttpSetting> endpoint) : IHttpRepository
    {
        private readonly HttpSetting _setting = endpoint.Value;
        public async Task<Response<IEnumerable<int>>> GetLocationIdsAsync()
        {
            try
            {
                var response = await http.GetAsync(_setting.Location.Url + _setting.Location.Endpoint.GetLocationId);
                return await response.Content.ReadFromJsonAsync<Response<IEnumerable<int>>>() ?? new Response<IEnumerable<int>>(DateTime.UtcNow.ToLocalTime(), HttpStatusCode.InternalServerError, Enumerable.Empty<int>(), ResponseMessage.INTERNAL_ERROR, []);
            }
            catch (Exception ex) 
            {
                return new Response<IEnumerable<int>>(DateTime.UtcNow.ToLocalTime(), HttpStatusCode.InternalServerError, Enumerable.Empty<int>(), ResponseMessage.INTERNAL_ERROR, []);
            }
           
        }

        public async Task<Response<bool>> IsAnyByLocationIdListAsync(IdList ids)
        {
            try
            {
                var response = await http.PostAsJsonAsync(_setting.Location.Url + _setting.Location.Endpoint.IsAnyByLocationIdList, ids);
                return await response.Content.ReadFromJsonAsync<Response<bool>>() ?? new Response<bool>(DateTime.UtcNow.ToLocalTime(), HttpStatusCode.InternalServerError, false, ResponseMessage.INTERNAL_ERROR, []);
            }
            catch (Exception ex) 
            {
             
                return new Response<bool>(DateTime.UtcNow.ToLocalTime(), HttpStatusCode.InternalServerError, false, ResponseMessage.INTERNAL_ERROR, []);
            }
            
        }
    }
}
