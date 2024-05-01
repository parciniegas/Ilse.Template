using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Queries.GetAll;

namespace Ilse.Start.Application.ToDo.Queries.GetAll;

public record AppGetAllToDosQuery() : IQuery
{
    public static GetAllToDosQuery GetAllToDosQuery()
    {
        return new GetAllToDosQuery();
    }
}

public record AppGetAllTodosQueryResponse(IEnumerable<ToDoItem> ToDoItems)
{
    public IEnumerable<ToDoItem> ToDoItems { get; private set; } = ToDoItems;

    public static AppGetAllTodosQueryResponse FromToDos(IEnumerable<ToDoItem>? todos)
    {
        return todos != null
            ? new AppGetAllTodosQueryResponse(todos)
            : new AppGetAllTodosQueryResponse(new List<ToDoItem>());
    }
}
