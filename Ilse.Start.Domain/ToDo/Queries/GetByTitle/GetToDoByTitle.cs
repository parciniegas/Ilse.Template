using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetByTitle;

public record GetToDoByTitleQuery(string Title): IQuery;

public record GetTodoByTitleQueryResponse(int Id, string Title, string Description, bool IsComplete)
{
    public static GetTodoByTitleQueryResponse FromToDoItem(ToDoItem todo)
    {
        return new GetTodoByTitleQueryResponse(todo.Id, todo.Title, todo.Description ?? string.Empty, todo.IsDone);
    }
}