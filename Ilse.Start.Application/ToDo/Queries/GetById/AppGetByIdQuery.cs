using Ilse.Start.Domain.ToDo.Queries.GetById;

namespace Ilse.Start.Application.ToDo.Queries.GetById;

public record AppGetByIdQuery(int Id) : GetToDoByIdQuery(Id);

public record AppGetToDoByIdQueryResponse(int Id, string Title, string Description, bool IsComplete)
    : GetTodoByIdQueryResponse(Id, Title, Description, IsComplete)
{
    public static AppGetToDoByIdQueryResponse FromBase(GetTodoByIdQueryResponse todo)
    {
        return new AppGetToDoByIdQueryResponse(todo.Id, todo.Title, todo.Description ?? string.Empty, todo.IsComplete);
    }
}
