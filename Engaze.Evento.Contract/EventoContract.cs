using System;
using System.Collections.Generic;

namespace Engaze.Evento.Contract
{
    public class EventoContract
    {
        public string Name { get; set; }

        public EventType EventType { get; set; }

        public string Description { get; set; }

        public Guid InitiatorId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IEnumerable<Guid> Participnats { get; set; }

        public LocationContract Destination { get; set; }

        public RecurrenceContract Recurrence { get; set; }

    }
}
