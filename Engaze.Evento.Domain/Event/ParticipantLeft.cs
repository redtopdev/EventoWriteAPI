using System;
using Engaze.EventSourcing.Core;

namespace Evento.Domain.Event
{
    public class ParticipantLeft : EventBase
    {
        public Guid ParticipantId { get; set; }
        public ParticipantLeft(Guid id, Guid participantId) : base(id)
        {
            this.ParticipantId = participantId;
        }
    }
}
