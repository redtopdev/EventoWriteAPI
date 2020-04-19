using System;
using System.Collections.Generic;
using System.Linq;
using Engaze.EventSourcing.Core;
using Evento.DataContract;
using Newtonsoft.Json;

namespace Evento.Domain.Event
{
    public class EventoCreated : EventBase
    {
        public EventoCreated()
        {
        }
        public EventoCreated(Guid aggregateId, EventoContract eventoContract) : base(aggregateId)
        {
            this.Name = eventoContract.Name;
            this.EventType = eventoContract.EventType;
            this.Description = eventoContract.Description;
            this.InitiatorId = eventoContract.InitiatorId;
            this.InitiatorName = eventoContract.InitiatorName;
            this.StartTime = eventoContract.StartTime;
            this.EndTime = eventoContract.EndTime;
            this.Participants = new List<Participant>();
            eventoContract.Participnats.ToList().ForEach(participant => this.Participants.Add(new Participant(participant, EventAcceptanceState.Pending)));
            this.Destination = JsonConvert.DeserializeObject<Location>(JsonConvert.SerializeObject(eventoContract.Destination));
            this.Duration = JsonConvert.DeserializeObject<Duration>(JsonConvert.SerializeObject(eventoContract.Duration));
            this.Tracking = JsonConvert.DeserializeObject<Duration>(JsonConvert.SerializeObject(eventoContract.Tracking));
            this.Reminder = JsonConvert.DeserializeObject<Reminder>(JsonConvert.SerializeObject(eventoContract.Reminder));
            this.EventState = eventoContract.EventState;
        }

        public string Name { get; private set; }

        public EventType EventType { get; private set; }

        public string Description { get; private set; }

        public Guid InitiatorId { get; private set; }
        public string InitiatorName { get; private set; }
        public EventState EventState { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public Location Destination { get; private set; }

        public List<Participant> Participants { get; private set; }

        public Recurrence Recurrence { get; private set; }

        public Duration Duration { get; private set; }

        public Reminder Reminder { get; private set; }

        public Duration Tracking { get; private set; }

    }
}
