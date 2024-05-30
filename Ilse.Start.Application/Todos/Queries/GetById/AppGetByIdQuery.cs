using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetById;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Application.Todos.Queries.GetById;

public record AppGetToDoByIdQuery(int Id) : IQuery
{
    public static AppGetToDoByIdQuery FromId(int id)
    {
        return new AppGetToDoByIdQuery(id);
    }

    public static GetToDoByIdQuery GetToDoByIdQuery(int id)
    {
        return new GetToDoByIdQuery(id);
    }
}

public record AppGetToDoByIdQueryResponse(Todo Todo)
    : GetTodoByIdQueryResponse(Todo)
{
    public static AppGetToDoByIdQueryResponse FromDomainResponse(GetTodoByIdQueryResponse todo)
    {
        return new AppGetToDoByIdQueryResponse(todo.Todo);
    }
}
