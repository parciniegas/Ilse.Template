using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetByStatus;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Application.Todos.Queries.GetByStatus;

public record AppGetToDosByStatusQuery(bool IsComplete) : IQuery
{
    public static AppGetToDosByStatusQuery FromStatus(bool isComplete) =>
        new AppGetToDosByStatusQuery(isComplete);
    public static GetToDosByStatusQuery GetToDoByStatusQuery(bool isComplete) =>
        new GetToDosByStatusQuery(isComplete);
}

public record AppGetToDosByStatusResponse(List<Todo> ToDoItems)
{
    public List<Todo> ToDoItems { get; private set; } = ToDoItems;

    public static OperationResult<AppGetToDosByStatusResponse> FromToDoItem(List<Todo>? todos)
    {
        return todos != null
            ? new AppGetToDosByStatusResponse(todos)
            : new AppGetToDosByStatusResponse([]);
    }
}
