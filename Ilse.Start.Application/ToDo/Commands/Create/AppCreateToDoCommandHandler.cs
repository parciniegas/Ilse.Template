using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Commands.Create;

namespace Ilse.Start.Application.ToDo.Commands.Create;

public class AppCreateToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCreateToDoCommand, OperationResult<AppCreateToDoCommandResponse>>
{
    public async Task<OperationResult<AppCreateToDoCommandResponse>> 
        HandleAsync(AppCreateToDoCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await commandDispatcher.ExecAsync<CreateToDoCommand, OperationResult<CreateToDoCommandResponse>>(command, cancellationToken);
        return new AppCreateToDoCommandResponse(result.Value!.Id);
    }
}
