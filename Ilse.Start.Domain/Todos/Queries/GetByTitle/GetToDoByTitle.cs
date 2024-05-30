using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetByTitle;

public record GetToDoByTitleQuery(string Title): IQuery;

public record GetToDoByTitleResponse(Todo Todo)
{
    public static GetToDoByTitleResponse FromToDoItem(Todo todo)
    {
        return new GetToDoByTitleResponse(todo);
    }
}
