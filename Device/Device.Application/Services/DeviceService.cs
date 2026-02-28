using Device.Application.DTOs;
using Device.Application.Entities;
using Device.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.Services
{
    public sealed class DeviceService : IDevice
    {
        public async Task<Response<DeviceDto>> AddAsync(CreateDeviceDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<DeviceDto>> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
