
namespace Evento.ApplicationService.Command
{
    using Evento.DataContract;
    using Engaze.EventSourcing.Core;
    using System;
    public class CreateEvento : BaseCommand
    {
        public EventoContract EventoContract { get; private set; }


        public CreateEvento(Guid eventId, EventoContract eventoContract) : base(eventId)
        {
            this.EventoContract = eventoContract;
        }
    }
}