using System;
using Engaze.Evento.Contract;
using Engaze.EventSourcing.Core;

namespace Engaze.Evento.Domain.Event
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
