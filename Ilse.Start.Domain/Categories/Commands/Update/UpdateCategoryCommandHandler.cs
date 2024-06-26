using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Categories.Errors;

namespace Ilse.Start.Domain.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(ICategoryRepository repository)
    : ICommandHandler<UpdateCategoryCommand, Result<UpdateCategoryCommandResponse>>
{
    public async Task<Result<UpdateCategoryCommandResponse>>
        HandleAsync(UpdateCategoryCommand command, CancellationToken cancellationToken = new())
    {
        if (command.IsAllNull)
            return CategoryErrors.NothingToUpdate();
        var category = await repository.GetByIdAsync(command.Id);
        if (category.IsNull())
            return CategoryErrors.CategoryNotFound(command.Id);
        if (command.IsEqual(category))
            return CategoryErrors.NothingToUpdate();
        if (command.Name is not null)
            category.Name = command.Name;
        if (command.Description is not null)
            category.Description = command.Description;
        await repository.UpdateAsync(category);
        return new UpdateCategoryCommandResponse(category.Id);
    }
}
