using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Categories.Errors;

namespace Ilse.Start.Domain.Categories.Commands.Create;

public class CreateCategoryCommandHandle(ICategoryRepository repository)
    : ICommandHandler<CreateCategoryCommand, OperationResult<CreateCategoryCommandResponse>>
{
    public async Task<OperationResult<CreateCategoryCommandResponse>>
        HandleAsync(CreateCategoryCommand command, CancellationToken cancellationToken = new())
    {
        var category = command.GetCategory();
        var exists = await repository.ExistsAsync(category.Name);
        if (exists)
            return CategoryErrors.CategoryAlreadyExists(category.Name);

        var id = await repository.CreateAsync(category);
        return new CreateCategoryCommandResponse(id);
    }
}
