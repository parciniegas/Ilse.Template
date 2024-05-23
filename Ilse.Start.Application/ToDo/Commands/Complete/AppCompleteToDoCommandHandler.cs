using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Commands.Complete;

namespace Ilse.Start.Application.ToDo.Commands.Complete;

public class AppCompleteToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCompleteToDoCommand, OperationResult<AppCompleteToDoCommandResponse>>
{
    public async Task<OperationResult<AppCompleteToDoCommandResponse>> HandleAsync(
        AppCompleteToDoCommand command,
        CancellationToken cancellationToken = default)
    {
        var result =
            await commandDispatcher.ExecAsync<CompleteTodoCommand, OperationResult<CompleteTodoCommandResponse>>(command, cancellationToken);
        return AppCompleteToDoCommandResponse.FromBool(result.Value!.Completed);
    }
}
