using CleanArchitecture.Solution.Domain.Common;
using CleanArchitecture.Solution.Domain.Entities;

namespace CleanArchitecture.Solution.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
