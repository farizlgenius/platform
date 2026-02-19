using Identity.Application.DTOs;
using Identity.Application.Entities;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Infrastructure.Mappers;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Identity.Infrastructure.Repositories
{
    public sealed class RoleRepository(AppDbContext context) : IRoleRepository
    {
        public async Task<int> AddAsync(Role data)
        {
            var en = RoleMapper.ToDb(data);
            await context.roles.AddAsync(en);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var en = await context.roles
                .Where(x => x.id == id)
                .OrderBy(x => x.id)
                .FirstOrDefaultAsync();

            if (en is null) return -1;

            context.roles.Remove(en);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleDto>> GetAsync()
        {
            var roles = await context.roles
               .AsNoTracking()
               .Select(r => new
               {
                   r.id,
                   r.name,
                   Features = r.features.Select(f => new FeatureDto(
                       f.id,
                       f.name,
                       f.module_id,
                       f.is_allow,
                       f.is_create,
                       f.is_modify,
                       f.is_delete,
                       f.is_action
                   ))
               })
               .ToListAsync();

            return roles
                .Select(r => new RoleDto(
                    r.id,
                    r.name,
                    r.Features.ToList()
                ))
                .ToList();

        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = await context.roles
                .AsNoTracking()
                .Where(r => r.id == id)
                .OrderBy(r => r.id)
                .Select(r => new
                {
                    r.id,
                    r.name,
                    Features = r.features.Select(f => new FeatureDto(
                        f.id,
                        f.name,
                        f.module_id,
                        f.is_allow,
                        f.is_create,
                        f.is_modify,
                        f.is_delete,
                        f.is_action
                    ))
                })
                .FirstOrDefaultAsync();

            if (role == null)
                return null;

            return new RoleDto(
                role.id,
                role.name,
                role.Features.ToList()
            );
        }

        public async Task<IEnumerable<RoleDto>> GetByLocationIdAsync(int locationId)
        {
            var roles = await context.roles
               .AsNoTracking()
               .Where(x => x.location_id == locationId)
               .Select(r => new
               {
                   r.id,
                   r.name,
                   Features = r.features.Select(f => new FeatureDto(
                       f.id,
                       f.name,
                       f.module_id,
                       f.is_allow,
                       f.is_create,
                       f.is_modify,
                       f.is_delete,
                       f.is_action
                   ))
               })
               .ToListAsync();

            return roles
                .Select(r => new RoleDto(
                    r.id,
                    r.name,
                    r.Features.ToList()
                ))
                .ToList();
        }

        public async Task<Pagination<RoleDto>> GetPaginationAsync(PaginationParam param, int location)
        {
            var query = context.roles.AsNoTracking().AsQueryable();


            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                if (!string.IsNullOrWhiteSpace(param.Search))
                {
                    var search = param.Search.Trim();

                    if (context.Database.IsNpgsql())
                    {
                        var pattern = $"%{search}%";

                        query = query.Where(x =>
                            EF.Functions.ILike(x.name, pattern) 
                        );
                    }
                    else // SQL Server
                    {
                        query = query.Where(x =>
                            x.name.Contains(search) 
                        );
                    }
                }
            }

            query = query.Where(x => x.location_id == location || x.location_id == 1);

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


            var roles = await query
                .AsNoTracking()
                .OrderByDescending(t => t.created_date)
                .Skip((param.PageNumber - 1) * param.PageSize)
                  .Select(r => new
                  {
                      r.id,
                      r.name,
                      Features = r.features.Select(f => new FeatureDto(
                          f.id,
                          f.name,
                          f.module_id,
                          f.is_allow,
                          f.is_create,
                          f.is_modify,
                          f.is_delete,
                          f.is_action
                      ))
                  })
               .ToListAsync();


            var data = roles
                .Select(r => new RoleDto(
                    r.id,
                    r.name,
                    r.Features.ToList()
                ))
                .ToList();


            return new Pagination<RoleDto>
            {
                Data = data,
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
            return await context.roles.AsNoTracking()
                .AnyAsync(x => x.id == component);
        }

        public async Task<bool> IsAnyByNameAsync(string name)
        {
            return await context.roles.AsNoTracking()
                .AnyAsync(r => r.Equals(name.Trim()));
        }

        public async Task<int> UpdateAsync(Role data)
        {
            var en = await context.roles
                .Where(r => r.id == data.Id)
                .OrderBy(r => r.id)
                .FirstOrDefaultAsync();

            if (en is null) return -1;

            RoleMapper.Update(data,en);

            context.roles.Update(en);
            return await context.SaveChangesAsync();


        }

        public async Task<bool> IsAnyReferenceByIdAsync(int id)
        {
            return await context.roles.AnyAsync(x => x.id == id && x.operators.Any());
        }

        public async Task<RoleDto> GetByNameAsync(string name)
        {
            var role = await context.roles
                .AsNoTracking()
                .Where(r => r.name.Equals(name.Trim()))
                .OrderBy(r => r.id)
                .Select(r => new
                {
                    r.id,
                    r.name,
                    Features = r.features.Select(f => new FeatureDto(
                        f.id,
                        f.name,
                        f.module_id,
                        f.is_allow,
                        f.is_create,
                        f.is_modify,
                        f.is_delete,
                        f.is_action
                    ))
                })
                .FirstOrDefaultAsync();

            if (role == null)
                return null;

            return new RoleDto(
                role.id,
                role.name,
                role.Features.ToList()
            );
        }
    }
}
