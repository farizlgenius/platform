using Messaging.Contracts.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts.Events.Operator
{
    public sealed record OperatorDeletedEvent(int OperatorId) : IntegrationEvent;

}
