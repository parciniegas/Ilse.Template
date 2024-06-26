using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos.Errors;

namespace Ilse.Start.Domain.Todos.Commands.Create;

public class CreateTodoCommandHandler(ITodoRepository repository)
: ICommandHandler<CreateToDoCommand, Result<CreateToDoCommandResponse>>
{
    public async Task<Result<CreateToDoCommandResponse>> HandleAsync(
        CreateToDoCommand command,
        CancellationToken cancellationToken = default)
    {
        var todo = command.GetTodo();
        var exists = await repository.ExistsAsync(todo.Title);
        if (exists)
            return ToDoErrors.ToDoAlreadyExists(todo.Title);

        var id = await repository.CreateAsync(todo);

        await repository.SaveChangesAsync();
        return CreateToDoCommandResponse.FromId(id);
    }
}
