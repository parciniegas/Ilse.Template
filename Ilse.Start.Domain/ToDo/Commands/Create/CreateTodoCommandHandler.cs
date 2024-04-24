using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Errors;

namespace Ilse.Start.Domain.ToDo.Commands.Create;

public class CreateTodoCommandHandler(IToDoRepository repository)
: ICommandHandler<CreateToDoCommand, OperationResult<CreateToDoCommandResponse>>
{
    public async Task<OperationResult<CreateToDoCommandResponse>> HandleAsync(
        CreateToDoCommand command,
        CancellationToken cancellationToken = default)
    {
        var todo = command.GetTodo();
        var exists = await repository.ExistsAsync(todo.Title);
        if (exists)
            return ToDoErrors.ToDoAlreadyExists(todo.Title);

        var id = await repository.CreateAsync(todo);
        return CreateToDoCommandResponse.FromId(id);
    }
}
