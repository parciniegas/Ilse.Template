using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetByTitle;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Application.Todos.Queries.GetByTitle;

public record AppGetToDoByTitleQuery(string Tittle) : IQuery
{
    public static GetToDoByTitleQuery GetToDoByTitleQuery(string tittle) =>
        new GetToDoByTitleQuery(tittle);

    public static AppGetToDoByTitleQuery FromTitle(string title) => new AppGetToDoByTitleQuery(title);
}

public record AppGetToDoByTitleResponse(Todo Todo)
{
    public static AppGetToDoByTitleResponse FromDomainResponse(GetToDoByTitleResponse response)
    {
        return new AppGetToDoByTitleResponse(response.Todo);
    }
}
