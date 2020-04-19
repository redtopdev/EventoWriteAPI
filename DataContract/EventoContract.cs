using System;
using System.Collections.Generic;

namespace Evento.DataContract
{
    public class EventoContract
    {
        public string Name { get; set; }

        public EventType EventType { get; set; }

        public string Description { get; set; }

        public Guid InitiatorId { get; set; }

        public string InitiatorName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Duration Duration { get; set; }

        public Duration Tracking { get; set; }

        public EventState EventState { get; set; }

        public IEnumerable<Guid> Participnats { get; set; }

        public Location Destination { get; set; }

        public Reminder Reminder { get; set; }

        public Recurrence Recurrence { get; set; }

    }
}
