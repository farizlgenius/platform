using Identity.Domain.Entities;
using Identity.Domain.Interfaces;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Identity.Infrastructure.Repositories
{
    public sealed class RoleRepository(AppDbContext context) : IRoleRepository
    {
        public async Task<int> AddAsync(Role data)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteByIdAsync(int component)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAsync()
        {
            var res = await context.roles
                .AsNoTracking()
                .OrderBy(x => x.id)
                .Select(x => new Role
                {
                    Id = x.id,
                    Name = x.name,
                    Features = x.features
                    .Select(x => new Feature
                    {
                        Id = x.id,
                        Name = x.name,
                        Path = x.path,
                        IsAllow = x.is_allow,
                        IsCreate = x.is_create,
                        IsModify = x.is_modify,
                        IsDelete = x.is_delete,
                        IsAction = x.is_active
                    }).ToList()
                })
                .ToArrayAsync();

            return res;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            var res = await context.roles
                .AsNoTracking()
                .Where(x => x.id == id)
                .OrderBy(x => x.id)
                .Select(x => new Role 
                {
                    Id = x.id,
                    Name = x.name,
                    Features = x.features
                    .Select(x => new Feature 
                    {
                        Id = x.id,
                        Name = x.name,
                        Path = x.path,
                        IsAllow = x.is_allow,
                        IsCreate = x.is_create,
                        IsModify = x.is_modify,
                        IsDelete = x.is_delete,
                        IsAction = x.is_active
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return res;
        }

        public async Task<IEnumerable<Role>> GetByLocationIdAsync(int locationId)
        {
            var res = await context.roles
                .AsNoTracking()
                .Where(x => x.location_id == locationId)
                .OrderBy(x => x.id)
                .Select(x => new Role
                {
                    Id = x.id,
                    Name = x.name,
                    Features = x.features
                    .Select(x => new Feature
                    {
                        Id = x.id,
                        Name = x.name,
                        Path = x.path,
                        IsAllow = x.is_allow,
                        IsCreate = x.is_create,
                        IsModify = x.is_modify,
                        IsDelete = x.is_delete,
                        IsAction = x.is_active
                    }).ToList()
                })
                .ToArrayAsync();

            return res;
        }

        public async Task<Pagination<Role>> GetPaginationAsync(PaginationParam param, int location)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAnyById(int component)
        {
            return await context.roles.AsNoTracking()
                .AnyAsync(x => x.id == component);
        }

        public async Task<int> UpdateAsync(Role newData)
        {
            throw new NotImplementedException();
        }
    }
}
