using Identity.Domain.Entities;
using Identity.Domain.Interfaces;
using Identity.Infrastructure.Mappers;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Identity.Infrastructure.Repositories
{
    public sealed class OperatorRepository(AppDbContext context) : IOperatorRepository
    {
        public async Task<int> AddAsync(Operator data)
        {
            var en = OperatorMapper.ToDb(data);
            await context.operators.AddAsync(en);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(int component)
        {
            var en = await context.operators
           .Where(x => x.id == component)
           .OrderBy(x => x.id)
           .FirstOrDefaultAsync();

            if (en is null) return 0;

            context.operators.Remove(en);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Operator>> GetAsync()
        {
            var res = await context.operators
                .AsNoTracking()
                 .Select(x => new Operator
                 {
                     Id = x.id,
                     UserId = x.userid,
                     Username = x.username,
                     Email = x.email,
                     Title = x.title,
                     FirstName = x.firstname,
                     MiddleName = x.middlename,
                     LastName = x.lastname,
                     Phone = x.phone,
                     Image = x.image,
                     LocationId = x.location_id,
                     IsActive = x.is_active,
                     Role = new Role
                     {
                         Id = x.role.id,
                         Name = x.role.name,
                         Features = x.role.features
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
                     }

                 })
                .ToArrayAsync();

            return res;
        }

        public async Task<Operator> GetByIdAsync(int id)
        {
            var res = await context.operators
                .AsNoTracking()
                .Where(x => x.id == id)
                .OrderBy(x => x.id)
                .Select(x => new Operator
                {
                    Id = x.id,
                    UserId = x.userid,
                    Username = x.username,
                    Email = x.email,
                    Title = x.title,
                    FirstName = x.firstname,
                    MiddleName = x.middlename,
                    LastName = x.lastname,
                    Phone = x.phone,
                    Image = x.image,
                    LocationId = x.location_id,
                    IsActive = x.is_active,
                    Role = new Role
                    {
                        Id = x.role.id,
                        Name = x.role.name,
                        Features = x.role.features
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
                    }

                })
                .FirstOrDefaultAsync();

            return res;
        }

        public async Task<IEnumerable<Operator>> GetByLocationIdAsync(int locationId)
        {
            var res = await context.operators
                .AsNoTracking()
                .Where(x => x.location_id == locationId)
                 .Select(x => new Operator
                 {
                     Id = x.id,
                     UserId = x.userid,
                     Username = x.username,
                     Email = x.email,
                     Title = x.title,
                     FirstName = x.firstname,
                     MiddleName = x.middlename,
                     LastName = x.lastname,
                     Phone = x.phone,
                     Image = x.image,
                     LocationId = x.location_id,
                     IsActive = x.is_active,
                     Role = new Role
                     {
                         Id = x.role.id,
                         Name = x.role.name,
                         Features = x.role.features
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
                     }

                 })
                .ToArrayAsync();

            return res;
        }

        public async Task<Operator> GetByUsernameAsync(string Username)
        {
            var res = await context.operators
                .AsNoTracking()
                .Where(x => x.username.Equals(Username))
                .OrderBy(x => x.id)
                .Select(x => new Operator 
                {
                    Id = x.id,
                    UserId = x.userid,
                    Username = x.username,
                    Email = x.email,
                    Title = x.title,
                    FirstName = x.firstname,
                    MiddleName = x.middlename,
                    LastName = x.lastname,
                    Phone = x.phone,
                    Image = x.image,
                    LocationId = x.location_id,
                    IsActive = x.is_active,
                    Role = new Role 
                    {
                        Id = x.role.id,
                        Name = x.role.name,
                        Features = x.role.features
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
                    }
                    
                })
                .FirstOrDefaultAsync();

            return res;
        }

        public async Task<Pagination<Operator>> GetPaginationAsync(PaginationParam param, int location)
        {
            var query = context.operators.AsNoTracking().AsQueryable();


            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                if (!string.IsNullOrWhiteSpace(param.Search))
                {
                    var search = param.Search.Trim();

                    if (context.Database.IsNpgsql())
                    {
                        var pattern = $"%{search}%";

                        query = query.Where(x =>
                            EF.Functions.ILike(x.userid, pattern) ||
                            EF.Functions.ILike(x.username, pattern) ||
                            EF.Functions.ILike(x.email, pattern) ||
                            EF.Functions.ILike(x.title, pattern) ||
                            EF.Functions.ILike(x.firstname, pattern) ||
                            EF.Functions.ILike(x.middlename, pattern) ||
                            EF.Functions.ILike(x.lastname, pattern) ||
                            EF.Functions.ILike(x.phone, pattern)

                        );
                    }
                    else // SQL Server
                    {
                        query = query.Where(x =>
                            x.username.Contains(search) ||
                            x.username.Contains(search) ||
                            x.email.Contains(search) ||
                            x.title.Contains(search) ||
                            x.firstname.Contains(search) ||
                            x.middlename.Contains(search) ||
                            x.lastname.Contains(search) ||
                            x.phone.Contains(search)
                        );
                    }
                }
            }

            query = query.Where(x => x.location_id == location || x.location_id == 0);

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


            var data = await query
                .AsNoTracking()
                .OrderByDescending(t => t.created_date)
                .Skip((param.PageNumber - 1) * param.PageSize)
                 .Select(x => new Operator
                 {
                     Id = x.id,
                     UserId = x.userid,
                     Username = x.username,
                     Email = x.email,
                     Title = x.title,
                     FirstName = x.firstname,
                     MiddleName = x.middlename,
                     LastName = x.lastname,
                     Phone = x.phone,
                     Image = x.image,
                     LocationId = x.location_id,
                     IsActive = x.is_active,
                     Role = new Role
                     {
                         Id = x.role.id,
                         Name = x.role.name,
                         Features = x.role.features
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
                     }

                 })
                .ToListAsync();


            return new Pagination<Operator>
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

        public async Task<string> GetPasswordByUsernameAsync(string Username)
        {
            var res = await context.operators
                .AsNoTracking()
                .Where(x => x.username.Equals(Username))
                .OrderBy(x => x.id)
                .Select(x => x.password)
                .FirstOrDefaultAsync();

            return res ?? "";
        }

        public async Task<bool> IsAnyById(int component)
        {
            return await context.operators.AsNoTracking()
                .AnyAsync(x => x.id == component);
        }

        public async Task<int> UpdateAsync(Operator data)
        {
            var en = await context.operators
            .Where(x => x.username.Equals(data.Username))
            .OrderBy(x => x.id)
            .FirstOrDefaultAsync();

            if (en is null) return 0;

            context.operators.Update(en);
            return await context.SaveChangesAsync();
        }
    }
}
