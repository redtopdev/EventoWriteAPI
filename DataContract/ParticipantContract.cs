﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.DataContract
{
    public class ParticipantContract
    {
        public ParticipantContract(Guid userID, EventAcceptanceState acceptanceState)
        {
            this.AcceptanceState = acceptanceState;
            this.UserId = userID;
        }
        public Guid UserId { get; private set; }
        public EventAcceptanceState AcceptanceState { get; private set; }
    }
}