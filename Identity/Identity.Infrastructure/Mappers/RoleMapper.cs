using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Mappers
{
    public sealed class RoleMapper
    {
        public static Identity.Infrastructure.Persistence.Entities.Role ToDb(Identity.Domain.Entities.Role data) 
        {
            return new Identity.Infrastructure.Persistence.Entities.Role
            {
                name = data.Name,
                features = data.Features.Select(x => new Persistence.Entities.Feature 
                {
                    name = x.Name,
                    path = x.Path,
                    is_allow = x.IsAllow,
                    is_create = x.IsCreate,
                    is_modify = x.IsModify,
                    is_delete = x.IsDelete,
                    is_action = x.IsAction,
                    is_active = true,
                    created_date = DateTime.UtcNow,
                    updated_date = DateTime.UtcNow,
                    
                }).ToArray(),
                location_id = data.LocationId,
                is_active = true,
                created_date = DateTime.UtcNow,
                updated_date = DateTime.UtcNow,
 
            };
        }

        public static void Update(Identity.Domain.Entities.Role data, Identity.Infrastructure.Persistence.Entities.Role en) 
        {
            en.name = data.Name;
            en.features = data.Features.Select(f => new Persistence.Entities.Feature 
            {
                name = f.Name,
                path = f.Path,
                role_id = data.Id,
                is_allow = f.IsAllow,
                is_create = f.IsCreate,
                is_modify = f.IsModify,
                is_delete = f.IsDelete,
                is_action = f.IsAction,
                is_active = true
            }).ToArray();
            en.updated_date = DateTime.UtcNow;
        }
    }
}
