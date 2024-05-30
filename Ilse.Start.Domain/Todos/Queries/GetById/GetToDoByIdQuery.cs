using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Domain.ToDo.Queries.GetById;

public record GetToDoByIdQuery(int Id) : IQuery;

public record GetTodoByIdQueryResponse(Todo Todo)
{
    public static GetTodoByIdQueryResponse FromToDoItem(Todo todo)
    {
        return new GetTodoByIdQueryResponse(todo);
    }
}
