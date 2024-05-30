using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Categories.Commands.Create;

namespace Ilse.Start.Application.Categories.Commands.Create;

public class AppCreateCategoryCommandHandler(ICommandDispatcher dispatcher)
    : ICommandHandler<AppCreateCategoryCommand, OperationResult<AppCreateCategoryCommandResponse>>
{
    public async Task<OperationResult<AppCreateCategoryCommandResponse>> HandleAsync(AppCreateCategoryCommand command, CancellationToken cancellationToken = new())
    {
        var domainCommand = AppCreateCategoryCommand.CreateCategoryCommand(command.Name, command.Description);
        var result = await dispatcher.ExecAsync<CreateCategoryCommand, OperationResult<CreateCategoryCommandResponse>>(domainCommand, cancellationToken);
        return result.IsSuccess
            ? AppCreateCategoryCommandResponse.FromDomainResponse(result.Value!)
            : result.Error!;
    }
}
