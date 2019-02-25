using System;
using System.Collections.Generic;
using Engaze.EventSourcing.Core;

namespace Engaze.Evento.Domain.Event
{
    public class ParticipantsListUpdated : EventBase
    {
        public ICollection<Guid> ParticipantList { get; set; }
        public ParticipantsListUpdated(Guid id, ICollection<Guid> participantList) : base(id)
        {
            this.ParticipantList = participantList;
        }
    }
}
