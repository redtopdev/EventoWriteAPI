
namespace Engaze.Evento.ApplicationService.Handler
{
    using Domain.Entity;
    using Engaze.Evento.ApplicationService.Command;

    using Engaze.Evento.Persistance;
    using Engaze.EventSourcing.Core;
    using System.Threading.Tasks;

    public class EventoCommandHandler : CommandHandler<Evento>
    {

        public EventoCommandHandler(IAggregateRespository<Evento> aggregateRespository) : base(aggregateRespository)
        {
            Register<CreateEvento>(processCommand);
            Register<EndEvento>(processCommand);
            Register<LeaveEvento>(processCommand);
            Register<DeleteEvento>(processCommand);
            Register<ExtendEvento>(processCommand);
            Register<UpdateParticipantList>(processCommand);
            Register<UpdateParticipantState>(processCommand);
        }

        protected async Task processCommand(CreateEvento command)
        {
            var engazeEvent = new Evento(command.Id, command.EventoContract);
            await repository.Save(engazeEvent);
        }

        protected async Task processCommand(EndEvento command)
        {
            var evento = await base.repository.Get(command.Id) as Evento;
            evento.EndEvent();
            await repository.Save(evento);
        }

        protected async Task processCommand(LeaveEvento command)
        {
            var evento = await base.repository.Get(command.Id) as Evento;
            evento.LeaveEvento(command.ParticipantId);
            await repository.Save(evento);
        }

        protected async Task processCommand(ExtendEvento command)
        {
            var evento = await base.repository.Get(command.Id) as Evento;
            evento.ExtendEvento(command.extendedTime);
            await repository.Save(evento);
        }

        protected async Task processCommand(DeleteEvento command)
        {
            var evento = await base.repository.Get(command.Id) as Evento;
            evento.DeleteEvent();
            await repository.Save(evento);
        }

        protected async Task processCommand(UpdateParticipantList command)
        {
            var evento = await base.repository.Get(command.Id) as Evento;
            evento.UpdateParticipantList(command.ParticipantList);
            await repository.Save(evento);
        }

        protected async Task processCommand(UpdateParticipantState command)
        {
            var evento = await base.repository.Get(command.Id) as Evento;
            evento.UpdateParticipantState(command.ParticipantId, command.State);
            await repository.Save(evento);
        }
    }
}
