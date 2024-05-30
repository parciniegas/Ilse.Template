using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Complete;

public record CompleteTodoCommand(int Id, string? Notes = null) : BaseCommand;

public record CompleteTodoCommandResponse(bool Completed)
{
    public static CompleteTodoCommandResponse FromBool(bool result)
    {
        return new CompleteTodoCommandResponse(result);
    }
}
