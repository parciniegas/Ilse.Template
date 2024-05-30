using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Categories.Errors;

namespace Ilse.Start.Domain.Categories.Commands.AddTodo;

public class AddTodoToCategoryCommandHandler(ICategoryRepository repository)
    : ICommandHandler<AddTodoToCategoryCommand, OperationResult<AddTodoToCategoryCommandResponse>>
{
    public async Task<OperationResult<AddTodoToCategoryCommandResponse>>
        HandleAsync(AddTodoToCategoryCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await repository.AddTodo(command.CategoryId, command.TodoId);
        if (result)
            return new AddTodoToCategoryCommandResponse(command.CategoryId);
        return CategoryErrors.CategoryNotFound(command.CategoryId);
    }
}
