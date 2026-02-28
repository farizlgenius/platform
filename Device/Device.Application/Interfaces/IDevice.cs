using Device.Application.DTOs;
using Device.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.Interfaces
{
    public interface IDevice
    {
        Task<Response<DeviceDto>> AddAsync(CreateDeviceDto dto);
        Task<Response<DeviceDto>> UpdateAsync();

    }
}
