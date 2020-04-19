using System;

namespace Engaze.EventSourcing.Core
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
