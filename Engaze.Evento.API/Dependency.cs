using Engaze.Evento.ApplicationService.Handler;
using Engaze.Evento.Persistance;
using Engaze.EventSourcing.Core;
using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Engaze.Evento.API
{
    public static class Dependency
    {
        public static IServiceCollection Configure(IServiceCollection services, IConfiguration config)
        {
            var connString = config.GetValue<string>("EVENTSTORE_CONNSTRING");
            //unable to reade from appsetting or environment variables so hard coding as of now.
            services.AddSingleton(x => EventStoreConnection.Create(new Uri(connString)));
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
