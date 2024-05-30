using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos;
using Ilse.Start.Domain.Todos.Queries.GetAll;

namespace Ilse.Start.Application.Todos.Queries.GetAll;

public record AppGetAllToDosQuery : IQuery
{
    public static GetAllToDosQuery GetAllToDosQuery()
    {
        return new GetAllToDosQuery();
    }
}

public record AppGetAllTodosQueryResponse(IEnumerable<Todo> ToDoItems)
{
    public IEnumerable<Todo> ToDoItems { get; private set; } = ToDoItems;

    public static AppGetAllTodosQueryResponse FromToDos(IEnumerable<Todo>? todos)
    {
        return todos != null
            ? new AppGetAllTodosQueryResponse(todos)
            : new AppGetAllTodosQueryResponse(new List<Todo>());
    }
}
