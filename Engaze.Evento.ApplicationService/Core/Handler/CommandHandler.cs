using Evento.DataPersistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engaze.EventSourcing.Core
{
    public abstract class CommandHandler<TDomain> where TDomain : IEventSourcingAggregate
    {
        protected readonly IAggregateRespository<TDomain> repository;

        public readonly Dictionary<Type, Func<BaseCommand, Task>> handlers = new Dictionary<Type, Func<BaseCommand, Task>>();
        public CommandHandler(IAggregateRespository<TDomain> aggregateRespository)
        {
            this.repository = aggregateRespository;
        }
       
        public virtual bool Validate<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            return true;
        }

        protected void Register<TCommand>(Func<TCommand, Task> processCommand) where TCommand : BaseCommand
        {
            handlers.Add(typeof(TCommand), async command =>
            {
                Validate(command);
                await processCommand((TCommand)command);

            });
        }

        public async Task Handle<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            await handlers[command.GetType()](command);           
        }
    }
}