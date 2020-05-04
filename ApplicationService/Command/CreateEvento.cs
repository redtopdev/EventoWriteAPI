
namespace Evento.ApplicationService.Command
{
    using Engaze.EventSourcing.Core;
    using System;
    public class CreateEvento : BaseCommand
    {
        public Engaze.Core.DataContract.Event EventoContract { get; private set; }


        public CreateEvento(Guid eventId, Engaze.Core.DataContract.Event eventoContract) : base(eventId)
        {
            this.EventoContract = eventoContract;
        }
    }
}