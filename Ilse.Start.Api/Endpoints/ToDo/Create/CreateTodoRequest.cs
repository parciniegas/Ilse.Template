using Ilse.Start.Application.Todos.Commands.Create;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Api.Endpoints.ToDo.Create;

public record CreateTodoRequest(string Title, int CategoryId, string? Description = null, List<Tag>? Tags = null)
{
    public AppCreateTodoCommand GetAppCreateToDoCommand()
    {
        return new AppCreateTodoCommand(Title, CategoryId, Description, Tags ?? []);
    }
}

public record CreateToDoRequestResponse(int Id);
