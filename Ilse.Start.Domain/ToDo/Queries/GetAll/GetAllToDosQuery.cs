using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetAll;

public record GetAllToDosQuery(): IQuery;

public record GetAllToDosQueryResponse(IEnumerable<ToDoItem> ToDoItems)
{
    public IEnumerable<ToDoItem> ToDoItems { get; private set; } = ToDoItems;

    public static GetAllToDosQueryResponse FromToDos(IEnumerable<ToDoItem>? todos)
    {
        return todos != null
            ? new GetAllToDosQueryResponse(todos)
            : new GetAllToDosQueryResponse(new List<ToDoItem>());
    }
}
