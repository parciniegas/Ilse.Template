using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Commands.AddNote;

namespace Ilse.Start.Application.ToDo.Commands.AddNote;

public class AppAddToDoNoteCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppAddToDoNoteCommand, OperationResult<AppAddToDoNoteCommandResponse>>
{
    public async Task<OperationResult<AppAddToDoNoteCommandResponse>>
        HandleAsync(AppAddToDoNoteCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainCommand = command.ToDomainCommand();
        var result = await commandDispatcher.ExecAsync<AddToDoNoteCommand, OperationResult<AppAddToDoNoteCommandResponse>>(domainCommand, cancellationToken);
        return AppAddToDoNoteCommandResponse.FromItem(result.Value!.Item);
    }
}
