using System;
using Engaze.EventSourcing.Core;

namespace Evento.Domain.Event
{
    public class EventoExtended : EventBase
    {
        public DateTime EndTime { get; set; }
        public EventoExtended(Guid id, DateTime endTime) : base(id)
        {
            this.EndTime = endTime;
        }
    }
}
