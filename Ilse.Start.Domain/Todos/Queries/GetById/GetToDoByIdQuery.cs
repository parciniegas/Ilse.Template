using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetById;

public record GetToDoByIdQuery(int Id) : IQuery;

public record GetTodoByIdQueryResponse(Todo Todo)
{
    public static GetTodoByIdQueryResponse FromToDoItem(Todo todo)
    {
        return new GetTodoByIdQueryResponse(todo);
    }
}
