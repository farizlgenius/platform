using Identity.Domain.Entities;
using Identity.Application.Interfaces;
using Identity.Infrastructure.Mappers;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Identity.Application.DTOs;
using Identity.Application.Entities;

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

        public async Task<IEnumerable<OperatorDto>> GetAsync()
        {
            var opers = await context.operators
                .AsNoTracking()
                 .Select(x => new 
                 {
                     Id = x.id,
                     UserId = x.userid,
                     Username = x.username,
                     Email = x.email,
                     Title = x.title,
                     Firstname = x.firstname,
                     Middlename = x.middlename,
                     Lastname = x.lastname,
                     Phone = x.phone,
                     Image = x.image,
                     LocationIds = x.operator_locations.Select(x => x.location_id),
                     IsActive = x.is_active,
                     Role = new RoleDto
                     (
                         x.role.id,
                         x.role.name,
                         x.role.features
                        .Select(x => new FeatureDto
                        (
                            x.id,
                           x.name,
                           x.module_id,
                           x.is_allow,
                           x.is_create,
                           x.is_modify,
                            x.is_delete,
                            x.is_active
                        ))
                     )

                 })
                .ToArrayAsync();

            return opers.Select(x => new OperatorDto(
                x.Id,
                x.UserId,
                x.Username,
                x.Email,
                x.Title,
                x.Firstname,
                x.Middlename,
                x.Lastname,
                x.Phone,
                x.Image,
                x.LocationIds.ToList(),
                x.IsActive,
                x.Role
                ));
        }

        public async Task<OperatorDto> GetByIdAsync(int id)
        {
            var res = await context.operators
                .AsNoTracking()
                .Where(x => x.id == id)
                .OrderBy(x => x.id)
                 .Select(x => new
                 {
                     Id = x.id,
                     UserId = x.userid,
                     Username = x.username,
                     Email = x.email,
                     Title = x.title,
                     Firstname = x.firstname,
                     Middlename = x.middlename,
                     Lastname = x.lastname,
                     Phone = x.phone,
                     Image = x.image,
                     LocationIds = x.operator_locations.Select(x => x.location_id),
                     IsActive = x.is_active,
                     Role = new RoleDto
                     (
                         x.role.id,
                         x.role.name,
                         x.role.features
                        .Select(x => new FeatureDto
                        (
                            x.id,
                           x.name,
                           x.module_id,
                           x.is_allow,
                           x.is_create,
                           x.is_modify,
                            x.is_delete,
                            x.is_active
                        ))
                     )

                 })
                .FirstOrDefaultAsync();

            if (res is null) return null;


            return new OperatorDto(
                res.Id,
                res.UserId,
                res.Username,
                res.Email,
                res.Title,
                res.Firstname,
                res.Middlename,
                res.Lastname,
                res.Phone,
                res.Image,
                res.LocationIds.ToList(),
                res.IsActive,
                res.Role
             );
        }

        public async Task<IEnumerable<OperatorDto>> GetByLocationIdAsync(int locationId)
        {
            var opers = await context.operators
                .AsNoTracking()
                .Where(x => x.operator_locations.Any(x => x.location_id == locationId))
                  .Select(x => new
                  {
                      Id = x.id,
                      UserId = x.userid,
                      Username = x.username,
                      Email = x.email,
                      Title = x.title,
                      Firstname = x.firstname,
                      Middlename = x.middlename,
                      Lastname = x.lastname,
                      Phone = x.phone,
                      Image = x.image,
                      LocationIds = x.operator_locations.Select(x => x.location_id),
                      IsActive = x.is_active,
                      Role = new RoleDto
                     (
                         x.role.id,
                         x.role.name,
                         x.role.features
                        .Select(x => new FeatureDto
                        (
                            x.id,
                           x.name,
                           x.module_id,
                           x.is_allow,
                           x.is_create,
                           x.is_modify,
                            x.is_delete,
                            x.is_active
                        ))
                     )

                  })
                .ToArrayAsync();

            return opers.Select(x => new OperatorDto(
                x.Id,
                x.UserId,
                x.Username,
                x.Email,
                x.Title,
                x.Firstname,
                x.Middlename,
                x.Lastname,
                x.Phone,
                x.Image,
                x.LocationIds.ToList(),
                x.IsActive,
                x.Role
                ));
        }

        public async Task<OperatorDto> GetByUsernameAsync(string Username)
        {
            var res = await context.operators
                .AsNoTracking()
                .Where(x => x.username.Equals(Username))
                .OrderBy(x => x.id)
                .Select(x => new
                {
                    Id = x.id,
                    UserId = x.userid,
                    Username = x.username,
                    Email = x.email,
                    Title = x.title,
                    Firstname = x.firstname,
                    Middlename = x.middlename,
                    Lastname = x.lastname,
                    Phone = x.phone,
                    Image = x.image,
                    LocationIds = x.operator_locations.Select(x => x.location_id),
                    IsActive = x.is_active,
                    Role = new RoleDto
                     (
                         x.role.id,
                         x.role.name,
                         x.role.features
                        .Select(x => new FeatureDto
                        (
                            x.id,
                           x.name,
                           x.module_id,
                           x.is_allow,
                           x.is_create,
                           x.is_modify,
                            x.is_delete,
                            x.is_active
                        ))
                     )

                })
                .FirstOrDefaultAsync();

            if (res is null) return null;

            return new OperatorDto(
                res.Id,
                res.UserId,
                res.Username,
                res.Email,
                res.Title,
                res.Firstname,
                res.Middlename,
                res.Lastname,
                res.Phone,
                res.Image,
                res.LocationIds.ToList(),
                res.IsActive,
                res.Role
             );
        }

        public async Task<Pagination<OperatorDto>> GetPaginationAsync(PaginationParam param, int location)
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

            query = query.Where(x => x.operator_locations.Any(x => x.location_id == location || x.location_id == 1));

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
                 .Select(x => new
                 {
                     Id = x.id,
                     UserId = x.userid,
                     Username = x.username,
                     Email = x.email,
                     Title = x.title,
                     Firstname = x.firstname,
                     Middlename = x.middlename,
                     Lastname = x.lastname,
                     Phone = x.phone,
                     Image = x.image,
                     LocationIds = x.operator_locations.Select(x => x.location_id),
                     IsActive = x.is_active,
                     Role = new RoleDto
                     (
                         x.role.id,
                         x.role.name,
                         x.role.features
                        .Select(x => new FeatureDto
                        (
                            x.id,
                           x.name,
                           x.module_id,
                           x.is_allow,
                           x.is_create,
                           x.is_modify,
                            x.is_delete,
                            x.is_active
                        ))
                     )

                 })
                .ToListAsync();


            var res = data.Select(x => new OperatorDto(
                x.Id,
                x.UserId,
                x.Username,
                x.Email,
                x.Title,
                x.Firstname,
                x.Middlename,
                x.Lastname,
                x.Phone,
                x.Image,
                x.LocationIds.ToList(),
                x.IsActive,
                x.Role
                ));


            return new Pagination<OperatorDto>
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

        public async Task<bool> IsAnyByUsernameAsync(string Username)
        {
            return await context.operators.AsNoTracking().AnyAsync(x => x.username.Equals(Username.Trim()));
        }

        public async Task<int> UpdateAsync(OperatorDto data)
        {
            var en = await context.operators
            .Where(x => x.username.Equals(data.Username))
            .OrderBy(x => x.id)
            .FirstOrDefaultAsync();

            if (en is null) return 0;

            context.operators.Update(en);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Operator data)
        {
            var en = await context.operators
            .Include(x => x.operator_locations)
            .Where(x => x.username.Equals(data.Username))
            .OrderBy(x => x.id)
            .FirstOrDefaultAsync();

            if (en is null) return 0;

            context.operator_locations.RemoveRange(en.operator_locations);

            context.operators.Update(en);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdatePasswordAsync(string username, string password)
        {
            var en = await context.operators
            .Where(x => x.username.Equals(username))
            .FirstOrDefaultAsync();

            if (en is null) return 0;

            en.password = password;

            context.operators.Update(en);
            return await context.SaveChangesAsync();
        }
    }
}
