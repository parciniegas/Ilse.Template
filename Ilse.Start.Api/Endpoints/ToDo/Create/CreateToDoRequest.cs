using Ilse.Start.Application.ToDo.Commands.Create;

namespace Ilse.Start.Api.Endpoints.ToDo.Create;

public record CreateToDoRequest(string Title, string? Description = null)
{
    public AppCreateToDoCommand CreateToDoCommand()
    {
        return new AppCreateToDoCommand(Title, Description);
    }
}

public record CreateToDoRequestResponse(int Id);