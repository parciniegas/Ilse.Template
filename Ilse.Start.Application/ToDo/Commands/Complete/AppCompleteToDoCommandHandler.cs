using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Errors;

namespace Ilse.Start.Application.ToDo.Commands.Complete;

public class AppCompleteToDoCommandHandler(IRepository repository)
    : ICommandHandler<AppCompleteToDoCommand, OperationResult<AppCompleteToDoCommandResponse>>
{
    public async Task<OperationResult<AppCompleteToDoCommandResponse>> HandleAsync(
        AppCompleteToDoCommand command,
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
        return AppCompleteToDoCommandResponse.FromItem(todo);
    }
}
