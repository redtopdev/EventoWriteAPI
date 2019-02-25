
using Engaze.EventSourcing.Core;
using System;

namespace Engaze.Evento.ApplicationService.Command
{
    public class ExtendEvento : BaseCommand
    {
        public ExtendEvento(Guid eventoId, DateTime extendedTime) : base(eventoId)
        {
            this.extendedTime = extendedTime;
        }
        public DateTime extendedTime { get; private set; }
    }
}
