using Ilse.Start.Domain.ToDo.Commands.Create;

namespace Ilse.Start.Application.ToDo.Commands.Create;

public record AppCreateToDoCommand(string Title, string? Description = null)
    : CreateToDoCommand(Title, Description);

public record AppCreateToDoCommandResponse(int Id);
