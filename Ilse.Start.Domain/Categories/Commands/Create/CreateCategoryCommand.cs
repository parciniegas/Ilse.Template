using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Categories.Commands.Create;

public record CreateCategoryCommand(string Name, string Description) : BaseCommand
{
    public Category GetCategory()
    {
        return new Category
        {
            Name = Name,
            Description = Description
        };
    }
}

public record CreateCategoryCommandResponse(int Id);
