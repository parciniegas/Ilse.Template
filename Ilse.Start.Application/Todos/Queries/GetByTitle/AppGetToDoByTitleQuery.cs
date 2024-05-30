using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos;
using Ilse.Start.Domain.Todos.Queries.GetByTitle;

namespace Ilse.Start.Application.Todos.Queries.GetByTitle;

public record AppGetToDoByTitleQuery(string Tittle) : IQuery
{
    public static GetToDoByTitleQuery GetToDoByTitleQuery(string tittle) => new(tittle);

    public static AppGetToDoByTitleQuery FromTitle(string title) => new(title);
}

public record AppGetToDoByTitleResponse(Todo Todo)
{
    public static AppGetToDoByTitleResponse FromDomainResponse(GetToDoByTitleResponse response)
    {
        return new AppGetToDoByTitleResponse(response.Todo);
    }
}
