using Engaze.EventSourcing.Core;
using System;
using System.Threading.Tasks;

namespace Engaze.Evento.Persistance
{
    public interface IAggregateRespository<TAggregate> where TAggregate : IEventSourcingAggregate
    {
        Task Save(TAggregate aggregate);
        Task<TAggregate> Get(Guid id);
    }
}
