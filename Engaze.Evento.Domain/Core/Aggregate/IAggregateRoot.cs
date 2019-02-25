
namespace Engaze.EventSourcing.Core
{
    using System;
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
