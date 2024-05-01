using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Queries.GetById;

namespace Ilse.Start.Application.ToDo.Queries.GetById;

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

public record AppGetToDoByIdQueryResponse(ToDoItem ToDoItem)
    : GetTodoByIdQueryResponse(ToDoItem)
{
    public static AppGetToDoByIdQueryResponse FromDomainResponse(GetTodoByIdQueryResponse todo)
    {
        return new AppGetToDoByIdQueryResponse(todo.ToDoItem);
    }
}
