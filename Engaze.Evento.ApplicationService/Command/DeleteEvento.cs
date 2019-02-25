
using Engaze.EventSourcing.Core;
using System;

namespace Engaze.Evento.ApplicationService.Command
{
    public class DeleteEvento : BaseCommand
    {
        public DeleteEvento(Guid eventoId) : base(eventoId)
        {

        }
    }
}
