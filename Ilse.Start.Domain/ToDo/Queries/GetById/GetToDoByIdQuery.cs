using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetById;

public record GetToDoByIdQuery(int Id) : IQuery;

public record GetTodoByIdQueryResponse(int Id, string Title, string Description, bool IsComplete)
{
    public static GetTodoByIdQueryResponse FromToDoItem(ToDoItem todo)
    {
        return new GetTodoByIdQueryResponse(todo.Id, todo.Title, todo.Description ?? string.Empty, todo.IsDone);
    }
}