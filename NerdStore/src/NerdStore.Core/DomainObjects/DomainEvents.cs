using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.DomainObjects
{
    public class DomainEvents : Event
    {
        public DomainEvents(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
