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

    public class ParticipantController : ServiceControllerBase
    {
        public ParticipantController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }


        [HttpPut(Routes.EventoParticipants)]
        public async Task<IActionResult> UpdateParticipantListAsync([FromRoute]Guid eventoId, ICollection<Guid> participants)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new UpdateParticipantList(eventoId, participants));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }


        [HttpPut(Routes.LeaveEvento)]
        public async Task<IActionResult> LeaveEvent([FromRoute]Guid eventoId, [FromRoute]Guid participantId)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new LeaveEvento(eventoId, participantId));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }


        [HttpPut(Routes.EventoParticipantState)]
        public async Task<IActionResult> UpdateParticipantState([FromRoute]Guid eventoId, [FromRoute]Guid participantId, [FromRoute]EventAcceptanceState acceptanceState)
        {
            await commandDispatcher.Dispatch<Domain.Entity.Evento>(new UpdateParticipantState(eventoId, participantId, acceptanceState));
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
    }
}