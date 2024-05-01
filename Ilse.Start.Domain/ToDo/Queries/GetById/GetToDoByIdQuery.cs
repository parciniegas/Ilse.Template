using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetById;

public record GetToDoByIdQuery(int Id) : IQuery;

public record GetTodoByIdQueryResponse(ToDoItem ToDoItem)
{
    public static GetTodoByIdQueryResponse FromToDoItem(ToDoItem todo)
    {
        return new GetTodoByIdQueryResponse(todo);
    }
}
