using Ilse.Core.Results;
using Ilse.Start.Domain.Todos.Commands.Complete;

namespace Ilse.Start.Application.Todos.Commands.Complete;

public record AppCompleteTodoCommand(int Id, string? Notes = null) : CompleteTodoCommand(Id, Notes);

public record AppCompleteTodoCommandResponse(bool Completed)
{
    public static OperationResult<AppCompleteTodoCommandResponse> FromBool(bool completed)
    {
        return new AppCompleteTodoCommandResponse(completed);
    }
}
