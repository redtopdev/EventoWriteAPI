﻿using System;
using Engaze.EventSourcing.Core;

namespace Evento.Domain.Event
{
    public class EventoDeleted : EventBase
    {
      
        public EventoDeleted(Guid id) : base(id)
        {
        }
    }
}
