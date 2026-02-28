

using Device.Application.DTOs;
using Device.Application.Entities;
using Device.Application.Interfaces;
using Device.Domain.Entities;
using Device.Domain.Enums;
using Device.Infrastructure.Persistance;
using Device.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Device.Infrastructure.Repositories
{
    public sealed class DeviceRepository(AppDbContext context) : IDeviceRepository
    {
        public async Task<int> AddAsync(Device.Domain.Entities.Devices data)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DeviceDto>> GetAsync()
        {
            var en = await context.devices
                .AsNoTracking()
                .Select(x => new
                {
                    x.id,
                    x.location_id,
                    x.is_active,
                    x.name,
                    x.type,
                    x.type_detail,
                    x.metadata,
                    x.last_sync,
                    x.modules,
                })
                .ToListAsync();

            var result = en.Select(x =>
            {

                object? parsedMetadata = x.type switch
                {
                    (int)DeviceType.Amico =>
                        JsonSerializer.Deserialize<AmicoMetadataDto>(x.metadata),

                    (int)DeviceType.Aero =>
                        JsonSerializer.Deserialize<AeroMetadataDto>(x.metadata),

                    _ => null
                };

                return new DeviceDto(
                    x.id,
                    x.location_id,
                    x.is_active,
                    x.name,
                    (DeviceType)x.type,
                    x.type_detail,
                    parsedMetadata == null ? new Dto() : parsedMetadata ,
                    x.last_sync,
                    x.modules.Select(x => new ModuleDto()).ToList()
                );
            });



            return result;
        }

        public async Task<DeviceDto> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DeviceDto>> GetByLocationIdAsync(int locationId)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<DeviceDto>> GetPaginationAsync(PaginationParam param, int location)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAnyById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Device.Domain.Entities.Devices data)
        {
            throw new NotImplementedException();
        }
    }
}
