﻿using System;
using System.Collections.Generic;
using Engaze.Evento.Contract;
using Engaze.EventSourcing.Core;

namespace Engaze.Evento.Domain.Event
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
            this.StartTime = eventoContract.StartTime;
            this.EndTime = eventoContract.EndTime;
            this.Participants = eventoContract.Participnats;
            this.Destination = eventoContract.Destination;

        }

        public string Name { get; set; }

        public EventType EventType { get; set; }

        public string Description { get; set; }

        public Guid InitiatorId { get; set; }

        public EventState EventState { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public LocationContract Destination { get; set; }

        public IEnumerable<Guid> Participants { get; set; }

        public RecurrenceContract Recurrence { get; set; }


    }
}
