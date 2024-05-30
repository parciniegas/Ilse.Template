using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos.Commands.Create;

namespace Ilse.Start.Application.Todos.Commands.Create;

public class AppCreateToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCreateTodoCommand, OperationResult<AppCreateToDoCommandResponse>>
{
    public async Task<OperationResult<AppCreateToDoCommandResponse>>
        HandleAsync(AppCreateTodoCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await commandDispatcher.ExecAsync<CreateToDoCommand, OperationResult<CreateToDoCommandResponse>>(command, cancellationToken);
        return result.IsSuccess
            ? AppCreateToDoCommandResponse.FromDomainResponse(result.Value!)
            : result.Error!;
    }
}
