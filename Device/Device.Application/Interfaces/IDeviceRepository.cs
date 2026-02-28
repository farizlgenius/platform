using Device.Application.DTOs;
using Device.Domain.Entities;

namespace Device.Application.Interfaces
{
    public interface IDeviceRepository : IBaseRepository<DeviceDto, Devices>
    {
    }
}
