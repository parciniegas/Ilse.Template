using Ilse.Start.Application.Categories.Commands.Create;

namespace Ilse.Start.Api.Endpoints.Category.Create;

public record CreateCategoryRequest(string Name, string Description)
{
    public AppCreateCategoryCommand GetAppCreateCategoryCommand()
        => new(Name, Description);
}

public record CreateCategoryRequestResponse(int Id);
