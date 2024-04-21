using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetById;

namespace Ilse.Start.Domain.ToDo.Queries.GetByStatus;

public record GetToDosByStatusQuery(bool IsDone): IQuery;

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