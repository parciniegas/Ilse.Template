using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace Ilse.Start.Domain.ToDo.Commands.Create;

public class CreateTodoCommandHandler(IRepository repository)
: ICommandHandler<CreateToDoCommand, OperationResult<CreateTodoCommandResponse>>
{
    public async Task<OperationResult<CreateTodoCommandResponse>> HandleAsync(
        CreateToDoCommand command,
        CancellationToken cancellationToken = default)
    {
        var id = await repository.GetNextSequenceAsync<ToDoItem>();
        var todo = command.GetTodo(id);
        _ = await repository.AddAsync(todo, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return CreateTodoCommandResponse.FromId(id);
    }
}