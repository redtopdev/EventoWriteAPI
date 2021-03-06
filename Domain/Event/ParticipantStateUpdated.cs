﻿using System;
using Engaze.EventSourcing.Core;
using Engaze.Core.DataContract;

namespace Evento.Domain.Event
{
    public class ParticipantStateUpdated : EventBase
    {
        public Guid ParticipantId { get; set; }
        public EventAcceptanceState NewState { get; set; }
        public ParticipantStateUpdated(Guid id, Guid participantId, EventAcceptanceState newState) : base(id)
        {
            this.ParticipantId = participantId;
            this.NewState = newState;
        }
    }
}
