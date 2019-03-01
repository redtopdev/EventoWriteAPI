using Engaze.Evento.ApplicationService.Command;
using Engaze.Evento.Contract;
using Engaze.EventSourcing.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engaze.Evento.API.Controllers
{

    public class EventoController : ServiceControllerBase
    {
        public EventoController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }

        [HttpPost(Routes.Evento)]
        public async Task<IActionResult> CreateEventAsync([FromBody]EventoContract evento)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new CreateEvento(Guid.NewGuid(), evento));
            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        [HttpPut(Routes.EndEvento)]
        public async Task<IActionResult> EndEventAsync([FromRoute]Guid eventoId)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new EndEvento(eventoId));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpPut(Routes.ExtendEvento)]
        public async Task<IActionResult> ExtendEventAsync([FromRoute]Guid eventoId, DateTime newTime)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new ExtendEvento(eventoId, newTime));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpDelete(Routes.DeleteEvento)]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid eventoId)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new DeleteEvento(eventoId));
            return new StatusCodeResult(StatusCodes.Status202Accepted);
        }
        
    }
}