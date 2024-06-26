using Ilse.Core.Results;
using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Todos.Commands.Complete;

public class CompleteToDoCommandHandler(ITodoRepository repository)
    : ICommandHandler<CompleteTodoCommand, Result<CompleteTodoCommandResponse>>
{
    public async Task<Result<CompleteTodoCommandResponse>> HandleAsync(
        CompleteTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CompleteAsync(command.Id, command.Notes??string.Empty);
        return CompleteTodoCommandResponse.FromBool(result);
    }
}
