using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetAll;

public record GetAllToDosQuery : IQuery;

public record GetAllToDosQueryResponse(IEnumerable<Todo> ToDoItems)
{
    public IEnumerable<Todo> ToDoItems { get; private set; } = ToDoItems;

    public static GetAllToDosQueryResponse FromToDos(IEnumerable<Todo>? todos)
    {
        return todos != null
            ? new GetAllToDosQueryResponse(todos)
            : new GetAllToDosQueryResponse(new List<Todo>());
    }
}
