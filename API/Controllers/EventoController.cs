using Engaze.Core.DataContract;
using Engaze.EventSourcing.Core;
using Evento.ApplicationService.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Evento.Service
{

    public class EventoController : ServiceControllerBase
    {
        public EventoController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }

        [HttpPost(Routes.Evento)]
        public async Task<IActionResult> CreateEventAsync([FromBody]Event evento)
        {
            Guid eventId = Guid.NewGuid();
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new CreateEvento(eventId, evento));
            return new ObjectResult(eventId) { StatusCode = StatusCodes.Status201Created };           
        }

        [HttpPut(Routes.EndEvento)]
        public async Task<IActionResult> EndEventAsync([FromRoute]Guid eventId)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new EndEvento(eventId));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpPut(Routes.ExtendEvento)]
        public async Task<IActionResult> ExtendEventAsync([FromRoute]Guid eventId, [FromRoute]DateTime endTime)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new ExtendEvento(eventId, endTime));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpDelete(Routes.DeleteEvento)]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid eventId)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new DeleteEvento(eventId));
            return new StatusCodeResult(StatusCodes.Status202Accepted);
        }
    }
}