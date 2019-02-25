

namespace Engaze.Evento.API
{
    public static class Routes
    {
        public const string Evento = "event";

        public const string DeleteEvento = "event/{eventId}";

        public const string LeaveEvento = "event/{eventId}/participnat/{participantId}/leave";

        public const string EndEvento = "event/{eventId}/end";

        public const string ExtendEvento = "event/{id}/extend/{endTime}";

        public const string EventoParticipants = "event/{id}/participants";

    }
}
