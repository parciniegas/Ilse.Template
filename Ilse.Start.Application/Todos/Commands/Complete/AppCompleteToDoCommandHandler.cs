using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos.Commands.Complete;

namespace Ilse.Start.Application.Todos.Commands.Complete;

public class AppCompleteToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCompleteTodoCommand, Result<AppCompleteTodoCommandResponse>>
{
    public async Task<Result<AppCompleteTodoCommandResponse>> HandleAsync(
        AppCompleteTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        var result =
            await commandDispatcher.ExecAsync<CompleteTodoCommand, Result<CompleteTodoCommandResponse>>(command, cancellationToken);
        return AppCompleteTodoCommandResponse.FromBool(result.Value!.Completed);
    }
}
