
using System.Threading.Tasks;

namespace Engaze.EventSourcing.Core
{
    public interface ICommandDispatcher
    {
        void Register<TAggregate>(CommandHandler<TAggregate> handler) where TAggregate : IEventSourcingAggregate;
        Task Dispatch(ICommand command);
    }
}
