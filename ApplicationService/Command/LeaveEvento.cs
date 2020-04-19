
using Engaze.EventSourcing.Core;
using System;

namespace Evento.ApplicationService.Command
{
    public class LeaveEvento : BaseCommand
    {
        public LeaveEvento(Guid eventoId, Guid participantId) : base(eventoId)
        {
            this.ParticipantId = participantId;
        }
        public Guid ParticipantId { get; private set; }
    }
}
