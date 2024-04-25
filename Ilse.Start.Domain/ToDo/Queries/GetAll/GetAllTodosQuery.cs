using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetAll;

public record GetAllTodosQuery(): IQuery;

public record GetAllTodosQueryResponse(IEnumerable<ToDoItem> ToDoItems)
{
    public IEnumerable<ToDoItem> ToDoItems { get; private set; } = ToDoItems;

    public static GetAllTodosQueryResponse FromToDos(IEnumerable<ToDoItem>? todos)
    {
        return todos != null
            ? new GetAllTodosQueryResponse(todos)
            : new GetAllTodosQueryResponse(new List<ToDoItem>());
    }
}
