using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Queries.GetByTitle;

namespace Ilse.Start.Application.ToDo.Queries.GetByTitle;

public record AppGetToDoByTitleQuery(string Tittle) : IQuery
{
    public static GetToDoByTitleQuery GetToDoByTitleQuery(string tittle) =>
        new GetToDoByTitleQuery(tittle);

    public static AppGetToDoByTitleQuery FromTitle(string title) => new AppGetToDoByTitleQuery(title);
}

public record AppGetToDoByTitleResponse(ToDoItem ToDoItem)
{
    public static AppGetToDoByTitleResponse FromDomainResponse(GetToDoByTitleResponse response)
    {
        return new AppGetToDoByTitleResponse(response.ToDoItem);
    }
}
