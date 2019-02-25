using Engaze.Evento.ApplicationService;
using Engaze.Evento.ApplicationService.Command;
using Engaze.Evento.ApplicationService.Handler;
using Engaze.Evento.Persistance;
using Engaze.EventSourcing.Core;
using EventStore.ClientAPI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engaze.Evento.API
{
    public static class Dependency
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddSingleton(x => EventStoreConnection.Create(new Uri("tcp://127.0.0.1:1113")));
            services.AddSingleton<IEventStore, EventStoreEventStore>();
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddSingleton<IAggregateRespository<Domain.Entity.Evento>, AggregateRespository<Domain.Entity.Evento>>();
            services.AddSingleton(x =>
            {
                ICommandDispatcher dispatcher = new CommandDispatcher();
                dispatcher.Register(new EventoCommandHandler(x.GetService<IAggregateRespository<Domain.Entity.Evento>>()));
                return dispatcher;
            });
            return services;
        }
    }
}
