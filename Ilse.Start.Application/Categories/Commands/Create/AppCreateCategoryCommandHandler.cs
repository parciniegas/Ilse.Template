using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Categories.Commands.Create;

namespace Ilse.Start.Application.Categories.Commands.Create;

public class AppCreateCategoryCommandHandler(ICommandDispatcher dispatcher)
    : ICommandHandler<AppCreateCategoryCommand, Result<AppCreateCategoryCommandResponse>>
{
    public async Task<Result<AppCreateCategoryCommandResponse>> HandleAsync(AppCreateCategoryCommand command, CancellationToken cancellationToken = new())
    {
        var domainCommand = AppCreateCategoryCommand.CreateCategoryCommand(command.Name, command.Description);
        var result = await dispatcher.ExecAsync<CreateCategoryCommand, Result<CreateCategoryCommandResponse>>(domainCommand, cancellationToken);
        return result.IsSuccess
            ? AppCreateCategoryCommandResponse.FromDomainResponse(result.Value!)
            : result.Error!;
    }
}
