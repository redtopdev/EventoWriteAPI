
using System;

namespace Engaze.EventSourcing.Core
{
    public class BaseCommand : ICommand
    {
        public BaseCommand(Guid Id)
        {
            this.Id = Id;
        }
        public Guid Id { get; set; }
    }
}
