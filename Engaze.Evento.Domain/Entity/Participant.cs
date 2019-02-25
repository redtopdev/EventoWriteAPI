using Engaze.Evento.Contract;
using System;


namespace Engaze.Evento.Domain.Entity
{
    public class Participant
    {
        internal Participant(Guid userId, EventAcceptanceState acceptanceState)
        {
            this.UserId = userId;
            this.AcceptanceState = acceptanceState;
        }
        public Guid UserId { get; private set; }
        public EventAcceptanceState AcceptanceState { get; private set; }

        public void UpdateAcceptanceState(EventAcceptanceState acceptanceState)
        {
            this.AcceptanceState = acceptanceState;
        }


    }
}
