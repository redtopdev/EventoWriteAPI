﻿using Engaze.Core.DataContract;
using Engaze.EventSourcing.Core;
using System;

namespace Evento.ApplicationService.Command
{
    public class UpdateParticipantState : BaseCommand
    {
        public UpdateParticipantState(Guid eventoId, Guid ParticipantId, EventAcceptanceState state) : base(eventoId)
        {
            this.ParticipantId = ParticipantId;
            this.State = state;
        }
        public Guid ParticipantId { get; private set; }
        public EventAcceptanceState State { get; private set; }
    }
}
