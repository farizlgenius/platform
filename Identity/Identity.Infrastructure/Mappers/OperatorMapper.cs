using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Mappers
{
    public sealed class OperatorMapper
    {
        public static Identity.Infrastructure.Persistence.Entities.Operator ToDb(Operator data)
        {
            return new Identity.Infrastructure.Persistence.Entities.Operator
            {
                userid = data.UserId,
                username = data.Username,
                password = data.Password,
                email = data.Email,
                title = data.Title,
                firstname = data.FirstName,
                middlename = data.MiddleName,
                lastname = data.LastName,
                phone = data.Phone,
                image = data.Image,
                role_id = data.RoleId,
                operator_locations = data.LocationIds.Select(x => new Persistence.Entities.OperatorLocation
                {
                    location_id = x,
                    created_date = DateTime.UtcNow,
                    updated_date = DateTime.UtcNow
                }).ToArray(),
                updated_date = DateTime.UtcNow,
                created_date = DateTime.UtcNow,
                is_active = true

            };
        }
    }
}
