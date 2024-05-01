using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetByTitle;

public record GetToDoByTitleQuery(string Title): IQuery;

public record GetToDoByTitleResponse(ToDoItem ToDoItem)
{
    public static GetToDoByTitleResponse FromToDoItem(ToDoItem todo)
    {
        return new GetToDoByTitleResponse(todo);
    }
}
