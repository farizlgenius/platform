using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts.Abstractions
{
    public interface IIntegrationEvent
    {
        Guid Id { get; }
        public DateTime Timestamp { get; }
    }
}
