using Engaze.EventSourcing.Core;

namespace Engaze.Evento.API.Controllers
{

    public class ParticipantController : ServiceControllerBase
    {
        public ParticipantController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }
    }
}