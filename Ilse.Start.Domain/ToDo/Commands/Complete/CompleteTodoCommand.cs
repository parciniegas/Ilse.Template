using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Complete;

public record CompleteTodoCommand(int Id, string? Notes = null) : BaseCommand;

public record CompleteTodoCommandResponse(int Id)
{
    public static CompleteTodoCommandResponse FromId(int id)
    {
        return new CompleteTodoCommandResponse(id);
    }
}
