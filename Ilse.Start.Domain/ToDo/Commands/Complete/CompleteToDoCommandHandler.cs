using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;
using Ilse.Start.Domain.ToDo.Errors;

namespace Ilse.Start.Domain.ToDo.Commands.Complete;

public class CompleteToDoCommandHandler(IRepository repository)
    : ICommandHandler<CompleteTodoCommand, OperationResult<CompleteTodoCommandResponse>>
{
    public async Task<OperationResult<CompleteTodoCommandResponse>> HandleAsync(
        CompleteTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        var todo = await repository.GetByIdAsync<ToDoItem, int>(command.Id, cancellationToken);
        if (todo is null)
        {
            return ToDoErrors.ToDoNotFound(command.Id);
        }
        todo.Complete(command.Notes);
        await repository.UpdateAsync(todo, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return CompleteTodoCommandResponse.FromId(command.Id);
    }
}