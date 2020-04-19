
using Engaze.EventSourcing.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.DataPersistance
{
    public interface IEventStore
    {

        Task<IEnumerable<EventWrapper>> ReadEventsAsync(string id);


        Task<AppendResult> AppendEventAsync(IDomainEvent @event);
          
    }
}
