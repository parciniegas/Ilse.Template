using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Domain.ToDo.Queries.GetByStatus;

public record GetToDosByStatusQuery(bool IsCompleted) : IQuery;

public record GetToDosByStatusQueryResponse(List<Todo> ToDoItems)
{
    public List<Todo> ToDoItems { get; private set; } = ToDoItems;

    public static OperationResult<GetToDosByStatusQueryResponse> FromToDoItem(List<Todo>? todos)
    {
        return todos != null
            ? new GetToDosByStatusQueryResponse(todos)
            : new GetToDosByStatusQueryResponse([]);
    }
}
