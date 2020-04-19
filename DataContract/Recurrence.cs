﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.DataContract
{
    public class Recurrence
    {
        public RecurrenceFrequency FrequencyType { get; set; }
        public int Count { get; set; }
        public int Frequency { get; set; }
        public string DaysOfWeek { get; set; }
        public int Remaining { get; set; }
        public DateTime ActualStartTime { get; set; }
    }
}
