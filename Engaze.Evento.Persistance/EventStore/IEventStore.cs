
using Engaze.EventSourcing.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engaze.Evento.Persistance
{
    public interface IEventStore
    {

        Task<IEnumerable<EventWrapper>> ReadEventsAsync(Guid id);


        Task<AppendResult> AppendEventAsync(IDomainEvent @event);
          
    }
}
