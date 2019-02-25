
using System;
using Engaze.EventSourcing.Core;
namespace Engaze.Evento.ApplicationService.Command
{
    public class ChangeEventoLocation : BaseCommand
    {
        public ChangeEventoLocation(Guid eventoId) : base(eventoId)
        {

        }
    }
}
