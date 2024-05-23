using Ilse.Core.Results;
using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Complete;

public class CompleteToDoCommandHandler(IToDoRepository repository)
    : ICommandHandler<CompleteTodoCommand, OperationResult<CompleteTodoCommandResponse>>
{
    public async Task<OperationResult<CompleteTodoCommandResponse>> HandleAsync(
        CompleteTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CompleteAsync(command.Id, command.Notes??string.Empty);
        return CompleteTodoCommandResponse.FromBool(result);
    }
}
