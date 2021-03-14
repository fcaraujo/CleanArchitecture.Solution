using CleanArchitecture.Solution.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace CleanArchitecture.Solution.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
