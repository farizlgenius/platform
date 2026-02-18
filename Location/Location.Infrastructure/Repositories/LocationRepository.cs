using Location.Application.DTOs;
using Location.Application.Entities;
using Location.Application.Interfaces;
using Location.Domain.Entities;
using Location.Infrastructure.Mappers;
using Location.Infrastructure.Persistence;
using Location.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Reflection.Emit;

namespace Location.Infrastructure.Repositories
{
    public sealed class LocationRepository(AppDbContext context) : ILocationRepository
    {
        public async Task<int> AddAsync(Location.Domain.Entities.Locations data)
        {
            var en = LocationMapper.ToDb(data);

            await context.locations.AddAsync(en);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> CheckReferenceByIdAsync(int id)
        {
            List<string> errors = new List<string>();

            // operator 
            if (await context.locations
                .AnyAsync(x => x.id == id && x.operator_locations.Count() > 1)
                )
            {
                errors.Add("Found relate operator");
            }


            //// hardware
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.hardwares.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate hardware");
            //}

            //// modules
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.modules.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate modules");
            //}

            //// CP
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.control_points.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate control point");
            //}

            //// MP
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.monitor_points.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate control point");
            //}

            //// ALVL
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.accesslevels.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate access level");
            //}

            //// AREA
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.areas.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate access level");
            //}

            //// Card Holders
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.cardholders.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate card holder");
            //}

            //// door 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.doors.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate door");
            //}

            //// MPG 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.monitor_groups.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate monitor group");
            //}

            

            //// Holiday 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.holidays.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate holiday");
            //}

            //// Cred 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.credentials.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate credential");
            //}

            //// reader 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.readers.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate reader");
            //}

            //// rex 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.request_exits.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate rex");
            //}

            //// strk 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.strikes.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate strike");
            //}

            //// proc 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.procedures.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate procedure");
            //}

            //// ac 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.actions.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate procedure");
            //}

            //// trigger 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.triggers.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate trigger");
            //}

            //// interval 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.intervals.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate interval");
            //}

            //// timezone 
            //if (await context.location
            //    .AnyAsync(x => x.component_id == component && x.timezones.Count() > 0)
            //    )
            //{
            //    errors.Add("Found relate timezone");
            //}

            return errors;
        }

        public async Task<int> CountAsync()
        {
            return await context.locations.CountAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var en = await context.locations
                .Where(x => x.id == id)
                .OrderBy(x => x.id)
                .FirstOrDefaultAsync();

            if (en is null) return 0;

            context.locations.Remove(en);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LocationDto>> GetAsync()
        {
            var location = await context.locations
                .AsNoTracking()
                .Select(x => new
                {
                    id = x.id,
                    name = x.name,
                    description = x.description,
                    operatorIds = x.operator_locations.Select(x => x.operator_id)
                })
                .ToArrayAsync();

            var res = new List<LocationDto>();
            foreach (var loc in location)
            {
                res.Add(new LocationDto(loc.id, loc.name, loc.description, loc.operatorIds.ToList()));
            }

            return res;


        }

        public async Task<LocationDto> GetByIdAsync(int id)
        {
            var locations = await context.locations
                .AsNoTracking()
                .Where(x => x.id == id)
                .Select(x => new
                {
                    id = x.id,
                    name = x.name,
                    description = x.description,
                    operatorIds = x.operator_locations.Select(x => x.operator_id)
                })
                .OrderBy(x => x.id)
                .FirstOrDefaultAsync();

            if (locations is null) return null;

            var res = new LocationDto(locations.id,locations.name,locations.description,locations.operatorIds.ToList());

            return res;
        }

        public async Task<LocationDto> GetByNameAsync(string name)
        {
            var location = await context.locations.AsNoTracking()
                .Where(x => x.name.Equals(name))
                .OrderBy(x => x.id)
                .Select(x => new
                {
                    id = x.id,
                    name = x.name,
                    description = x.description,
                    operatorIds = x.operator_locations.Select(x => x.operator_id)
                })
                .FirstOrDefaultAsync();

            if (location is null) return null;

            var res = new LocationDto(location.id, location.name, location.description, location.operatorIds.ToList());

            return res;
        }

        public async Task<IdList> GetIdsAsync()
        {
            var ids = await context.locations
                .AsNoTracking()
                .Select(x => x.id)
                .ToArrayAsync();

            return new IdList(ids);
        }

        public async Task<IEnumerable<LocationDto>> GetLocationListByIdsAsync(IdList ids)
        {
            var res = new List<LocationDto>();
            var location = await context.locations
                .AsNoTracking()
                .Where(x => ids.Ids.Contains(x.id))
                .Select(x => new
                {
                    id = x.id,
                    name = x.name,
                    description = x.description,
                    operatorIds = x.operator_locations.Select(x => x.operator_id).ToArray()
                })
                .ToArrayAsync();

            foreach(var loc in location)
            {
                res.Add(new LocationDto(loc.id, loc.name, loc.description, loc.operatorIds.ToList()));
            }

            return res;
        }

        public async Task<Pagination<LocationDto>> GetPaginationAsync(PaginationParam param)
        {
            var query = context.locations.AsNoTracking().AsQueryable();


            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                if (!string.IsNullOrWhiteSpace(param.Search))
                {
                    var search = param.Search.Trim();

                    if (context.Database.IsNpgsql())
                    {
                        var pattern = $"%{search}%";

                        query = query.Where(x =>
                            EF.Functions.ILike(x.name, pattern) ||
                            EF.Functions.ILike(x.description, pattern) 

                        );
                    }
                    else // SQL Server
                    {
                        query = query.Where(x =>
                            x.name.Contains(search) ||
                            x.description.Contains(search) 
                        );
                    }
                }
            }

          

            if (param.StartDate != null)
            {
                var startUtc = DateTime.SpecifyKind(param.StartDate.Value, DateTimeKind.Utc);
                query = query.Where(x => x.created_date >= startUtc);
            }

            if (param.EndDate != null)
            {
                var endUtc = DateTime.SpecifyKind(param.EndDate.Value, DateTimeKind.Utc);
                query = query.Where(x => x.created_date <= endUtc);
            }

            var count = await query.CountAsync();


            var location = await query
                .AsNoTracking()
                .OrderByDescending(t => t.created_date)
                .Skip((param.PageNumber - 1) * param.PageSize)
                 .Select(x => new
                 {
                     id = x.id,
                     name = x.name,
                     description = x.description,
                     operatorIds = x.operator_locations.Select(x => x.operator_id)
                 })
                .ToListAsync();

            var res = new List<LocationDto>();

            foreach (var loc in location)
            {
                res.Add(new LocationDto(loc.id, loc.name, loc.description, loc.operatorIds.ToList()));
            }


            return new Pagination<LocationDto>
            {
                Data = res,
                Page = new PaginationData
                {
                    TotalCount = count,
                    PageNumber = param.PageNumber,
                    PageSize = param.PageSize,
                    TotalPage = (int)Math.Ceiling(count / (double)param.PageSize)
                }
            };
        }


        public async Task<bool> IsAnyById(int component)
        {
            return await context.locations.AsNoTracking().AnyAsync(x => x.id == component);
        }

        public async Task<bool> IsAnyByNameAsync(string name)
        {
            return await context.locations.AsNoTracking().AnyAsync(x => x.name.Equals(name.Trim()));
        }

        public async Task<bool> IsAnyLocationIdAsync(int id)
        {
            return await context.locations.AsNoTracking().AnyAsync(x => x.id == id);
        }

        public async Task<int> UpdateAsync(Location.Domain.Entities.Locations data)
        {
            var en = await context.locations
                .Where(x => x.id == data.Id)
                .OrderBy(x => x.id)
                .FirstOrDefaultAsync();

            if (en is null) return 0;

            LocationMapper.Update(data,en);

            return await context.SaveChangesAsync();
        }
    }
}
