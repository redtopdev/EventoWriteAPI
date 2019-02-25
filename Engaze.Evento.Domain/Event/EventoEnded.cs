using System;
using Engaze.EventSourcing.Core;

namespace Engaze.Evento.Domain.Event
{
    public class EventoEnded : EventBase
    {
        public DateTime EndTime { get; set; }
        public EventoEnded(Guid id, DateTime endTime) : base(id)
        {
            this.EndTime = endTime;
        }
    }
}
