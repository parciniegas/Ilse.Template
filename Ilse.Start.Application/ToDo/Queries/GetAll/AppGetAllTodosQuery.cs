using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Queries.GetAll;

namespace Ilse.Start.Application.ToDo.Queries.GetAll;

public record AppGetAllTodosQuery() : IQuery
{
    public GetAllTodosQuery GetAllTodosQuery()
    {
        return new GetAllTodosQuery();
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
