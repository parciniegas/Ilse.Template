using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos.Commands.Create;

namespace Ilse.Start.Application.Todos.Commands.Create;

public class AppCreateToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCreateTodoCommand, Result<AppCreateToDoCommandResponse>>
{
    public async Task<Result<AppCreateToDoCommandResponse>>
        HandleAsync(AppCreateTodoCommand command, CancellationToken cancellationToken = new())
    {
        var result = await commandDispatcher.ExecAsync<CreateToDoCommand, Result<CreateToDoCommandResponse>>(command, cancellationToken);
        return result.IsSuccess
            ? AppCreateToDoCommandResponse.FromDomainResponse(result.Value!)
            : result.Error!;
    }
}
