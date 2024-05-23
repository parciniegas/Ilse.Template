using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Commands.Create;

namespace Ilse.Start.Application.ToDo.Commands.Create;

public record AppCreateToDoCommand(string Title, string? Description = null, List<Tag>? Tags = null)
    : CreateToDoCommand(Title, Description, Tags);

public record AppCreateToDoCommandResponse(int Id);
