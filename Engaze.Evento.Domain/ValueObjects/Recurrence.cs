﻿using Engaze.Evento.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engaze.Evento.Domain.ValueObjects
{
    public class Recurrence : ValueObject<Recurrence>
    {
        public RecurrenceFrequency FrequencyType { get; set; }
        public int Count { get; set; }
        public int Frequency { get; set; }
        public string DaysOfWeek { get; set; }

        public int Remaining { get; set; }
        public DateTime ActualStartTime { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>
            {
                FrequencyType, Count, Frequency, DaysOfWeek, Remaining, ActualStartTime
            };
        }
    }
}
