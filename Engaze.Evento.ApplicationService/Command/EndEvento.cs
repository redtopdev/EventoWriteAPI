﻿
using Engaze.EventSourcing.Core;
using System;

namespace Engaze.Evento.ApplicationService.Command
{
    public class EndEvento: BaseCommand
    {
        public EndEvento( Guid eventoId) : base(eventoId)
        {

        }
    }
}
