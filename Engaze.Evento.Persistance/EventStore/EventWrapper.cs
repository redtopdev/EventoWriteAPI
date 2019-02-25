using Engaze.EventSourcing.Core;

namespace Engaze.Evento.Persistance
{
    public class EventWrapper
    {
        public EventWrapper(IDomainEvent domainEvent, long eventNumber)
        {
            DomainEvent = domainEvent;
            EventNumber = eventNumber;
        }

        public long EventNumber { get; }

        public IDomainEvent DomainEvent { get; }
    }



}
