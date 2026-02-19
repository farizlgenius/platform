using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts.Abstractions
{
    public abstract record IntegrationEvent : IIntegrationEvent
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    }
}
