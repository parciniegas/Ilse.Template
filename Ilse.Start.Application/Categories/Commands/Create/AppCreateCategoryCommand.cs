using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Categories.Commands.Create;

namespace Ilse.Start.Application.Categories.Commands.Create;

public record AppCreateCategoryCommand(string Name, string Description) : BaseCommand
{
    public static CreateCategoryCommand CreateCategoryCommand(string name, string description)
    {
        return new CreateCategoryCommand(name, description);
    }
}

public record AppCreateCategoryCommandResponse(int Id)
{
    public static AppCreateCategoryCommandResponse FromDomainResponse(CreateCategoryCommandResponse value)
    {
        return new AppCreateCategoryCommandResponse(value.Id);
    }
}
