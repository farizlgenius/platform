using Location.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Infrastructure.Mappers
{
    public sealed class LocationMapper
    {
        public static Locations ToDb(Location.Domain.Entities.Locations data) 
        {
            return new Locations
            {
                name = data.Name,
                description = data.Description,
                operator_locations = new List<OperatorLocation> 
                {
                    new OperatorLocation
                    {
                        operator_id = 1,
                        is_active = true
                    }
                },
                is_active = true,
                created_date = DateTime.UtcNow,
                updated_date = DateTime.UtcNow,
            };
        }

        public static void Update(Location.Domain.Entities.Locations data,Location.Infrastructure.Persistence.Entities.Locations en)
        {
           en.name = data.Name;
            en.description = data.Description;
            en.updated_date = DateTime.UtcNow;
            
        }
    }
}
