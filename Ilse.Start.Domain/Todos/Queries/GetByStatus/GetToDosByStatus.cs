using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetByStatus;

public record GetToDosByStatusQuery(bool IsCompleted) : IQuery;

public record GetToDosByStatusQueryResponse(List<Todo> ToDoItems)
{
    public List<Todo> ToDoItems { get; private set; } = ToDoItems;

    public static Result<GetToDosByStatusQueryResponse> FromToDoItem(List<Todo>? todos)
    {
        return todos != null
            ? new GetToDosByStatusQueryResponse(todos)
            : new GetToDosByStatusQueryResponse([]);
    }
}
