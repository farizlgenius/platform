using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Domain.Events
{
    public sealed record OperatorCreatedEvent(int operatorId, List<int> locationIds);
}
