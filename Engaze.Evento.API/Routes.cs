﻿

namespace Engaze.Evento.API
{
    public static class Routes
    {
        public const string Evento = "event";

        public const string DeleteEvento = "event/{eventId}";

        public const string LeaveEvento = "event/{eventId}/participnat/{participantId}/leave";

        public const string EndEvento = "event/{eventId}/end";

        public const string ExtendEvento = "event/{eventId}/extend/{endTime}";

        public const string EventoParticipants = "event/{eventId}/participants";

        public const string EventoParticipantState = "event/{eventId}/participant/{participantId}/state/{state}";       

    }
}
