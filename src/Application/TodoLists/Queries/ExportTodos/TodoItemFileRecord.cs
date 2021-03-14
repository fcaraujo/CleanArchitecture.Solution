using CleanArchitecture.Solution.Application.Common.Mappings;
using CleanArchitecture.Solution.Domain.Entities;

namespace CleanArchitecture.Solution.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
