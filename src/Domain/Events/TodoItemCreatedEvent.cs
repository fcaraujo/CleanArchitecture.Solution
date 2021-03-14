using CleanArchitecture.Solution.Domain.Common;
using CleanArchitecture.Solution.Domain.Entities;

namespace CleanArchitecture.Solution.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
