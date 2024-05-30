using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos;
using Ilse.Start.Domain.Todos.Queries.GetById;

namespace Ilse.Start.Application.Todos.Queries.GetById;

public record AppGetTodoByIdQuery(int Id) : IQuery
{
    public static AppGetTodoByIdQuery FromId(int id)
    {
        return new AppGetTodoByIdQuery(id);
    }

    public static GetToDoByIdQuery GetToDoByIdQuery(int id)
    {
        return new GetToDoByIdQuery(id);
    }
}

public record AppGetTodoByIdQueryResponse(Todo Todo)
    : GetTodoByIdQueryResponse(Todo)
{
    public static AppGetTodoByIdQueryResponse FromDomainResponse(GetTodoByIdQueryResponse todo)
    {
        return new AppGetTodoByIdQueryResponse(todo.Todo);
    }
}
