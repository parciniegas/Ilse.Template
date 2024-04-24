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
        var todo = await repository.GetByIdAsync(command.Id);
        todo.Complete(command.Notes);
        await repository.UpdateAsync(todo);
        return CompleteTodoCommandResponse.FromItem(todo);
    }
}