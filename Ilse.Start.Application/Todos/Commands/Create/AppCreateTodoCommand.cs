using Ilse.Core.Results;
using Ilse.Start.Domain.Todos;
using Ilse.Start.Domain.Todos.Commands.Create;

namespace Ilse.Start.Application.Todos.Commands.Create;

public record AppCreateTodoCommand(string Title, int CategoryId, string? Description = null, List<Tag>? Tags = null)
    : CreateToDoCommand(Title, CategoryId, Description, Tags);

public record AppCreateToDoCommandResponse(int Id)
{
    public static AppCreateToDoCommandResponse FromDomainResponse(CreateToDoCommandResponse value)
    {
        return new AppCreateToDoCommandResponse(value.Id);
    }
}
