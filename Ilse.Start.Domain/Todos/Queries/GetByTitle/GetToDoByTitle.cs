using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Domain.ToDo.Queries.GetByTitle;

public record GetToDoByTitleQuery(string Title): IQuery;

public record GetToDoByTitleResponse(Todo Todo)
{
    public static GetToDoByTitleResponse FromToDoItem(Todo todo)
    {
        return new GetToDoByTitleResponse(todo);
    }
}
