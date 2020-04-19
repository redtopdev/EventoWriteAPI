using Engaze.EventSourcing.Core;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Service
{
    [ApiController]
    public class ServiceControllerBase : ControllerBase
    {
        protected readonly ICommandDispatcher commandDispatcher;

        public ServiceControllerBase(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }      
    }
}
