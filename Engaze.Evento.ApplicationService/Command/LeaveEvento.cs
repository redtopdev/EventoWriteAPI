
using Engaze.EventSourcing.Core;
using System;

namespace Engaze.Evento.ApplicationService.Command
{
    public class LeaveEvento : BaseCommand
    {
        public LeaveEvento(Guid eventoId, Guid requesterId) : base(eventoId)
        {
            this.RequesterId = requesterId;
        }
        public Guid RequesterId { get; private set; }
    }
}
