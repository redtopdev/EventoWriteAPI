using Engaze.EventSourcing.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engaze.Evento.ApplicationService.Command
{
    public class UpdateParticipantList: BaseCommand
    {
        public UpdateParticipantList(Guid eventoId, ICollection<Guid> participantList) : base(eventoId)
        {
            this.ParticipantList = participantList;
        }
        public ICollection<Guid> ParticipantList { get; private set; }
    }
}
