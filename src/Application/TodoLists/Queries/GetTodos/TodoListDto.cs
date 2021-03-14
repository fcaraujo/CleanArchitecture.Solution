using CleanArchitecture.Solution.Application.Common.Mappings;
using CleanArchitecture.Solution.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Solution.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}
