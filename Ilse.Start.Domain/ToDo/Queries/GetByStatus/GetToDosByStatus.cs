using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetByStatus;

public record GetToDosByStatusQuery(bool IsCompleted) : IQuery;

public record GetToDosByStatusQueryResponse(List<ToDoItem> ToDoItems)
{
    public List<ToDoItem> ToDoItems { get; private set; } = ToDoItems;

    public static OperationResult<GetToDosByStatusQueryResponse> FromToDoItem(List<ToDoItem>? todos)
    {
        return todos != null
            ? new GetToDosByStatusQueryResponse(todos)
            : new GetToDosByStatusQueryResponse([]);
    }
}
