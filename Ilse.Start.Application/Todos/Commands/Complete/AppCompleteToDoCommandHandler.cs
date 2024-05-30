using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Commands.Complete;

namespace Ilse.Start.Application.Todos.Commands.Complete;

public class AppCompleteToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCompleteTodoCommand, OperationResult<AppCompleteTodoCommandResponse>>
{
    public async Task<OperationResult<AppCompleteTodoCommandResponse>> HandleAsync(
        AppCompleteTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        var result =
            await commandDispatcher.ExecAsync<CompleteTodoCommand, OperationResult<CompleteTodoCommandResponse>>(command, cancellationToken);
        return AppCompleteTodoCommandResponse.FromBool(result.Value!.Completed);
    }
}
