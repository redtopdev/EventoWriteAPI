using System;


namespace Engaze.Evento.Domain.Entity
{
    class EventRecurrance
    {
        public Guid EventId { get; set; }      
        public int RecurrenceFrequencyTypeId { get; set; }
        public int RecurrenceCount { get; set; }
        public int RecurrenceFrequency { get; set; }
        public string RecurrenceDaysOfWeek { get; set; }
    }
}
