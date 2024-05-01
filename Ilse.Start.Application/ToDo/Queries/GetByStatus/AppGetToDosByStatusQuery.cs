using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Queries.GetByStatus;

namespace Ilse.Start.Application.ToDo.Queries.GetByStatus;

public record AppGetToDosByStatusQuery(bool IsComplete) : IQuery
{
    public static AppGetToDosByStatusQuery FromStatus(bool isComplete) =>
        new AppGetToDosByStatusQuery(isComplete);
    public static GetToDosByStatusQuery GetToDoByStatusQuery(bool isComplete) =>
        new GetToDosByStatusQuery(isComplete);
}

public record AppGetToDosByStatusResponse(List<ToDoItem> ToDoItems)
{
    public List<ToDoItem> ToDoItems { get; private set; } = ToDoItems;

    public static OperationResult<AppGetToDosByStatusResponse> FromToDoItem(List<ToDoItem>? todos)
    {
        return todos != null
            ? new AppGetToDosByStatusResponse(todos)
            : new AppGetToDosByStatusResponse([]);
    }
}
