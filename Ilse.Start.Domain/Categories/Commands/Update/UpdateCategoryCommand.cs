using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Categories.Commands.Update;

public record UpdateCategoryCommand(int Id, string? Name = null, string? Description = null)
    : BaseCommand
{
    public bool IsAllNull => Name == null && Description == null;
    public bool IsEqual(Category category) => Name == category.Name && Description == category.Description;
}

public record UpdateCategoryCommandResponse(int Id);
