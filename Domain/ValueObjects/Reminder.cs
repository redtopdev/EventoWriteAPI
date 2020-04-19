using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Domain.ValueObjects
{
    public class Reminder: ValueObject<Reminder>
    {
        public int TimeInterval { get; set; }

        public string Period { get; set; }

        public string NotificationType { get; set; }

        public long ReminderOffsetInMinute { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>
            {
                TimeInterval, Period, NotificationType, ReminderOffsetInMinute
            };
        }
    }
}
