using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Commands.AddNote;

namespace Ilse.Start.Application.Todos.Commands.AddNote;

public class AppAddToDoNoteCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppAddTodoNoteCommand, OperationResult<AppAddTodoNoteCommandResponse>>
{
    public async Task<OperationResult<AppAddTodoNoteCommandResponse>>
        HandleAsync(AppAddTodoNoteCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainCommand = command.ToDomainCommand();
        var result = await commandDispatcher.ExecAsync<AddToDoNoteCommand, OperationResult<AppAddTodoNoteCommandResponse>>(domainCommand, cancellationToken);
        return AppAddTodoNoteCommandResponse.FromItem(result.Value!.Item);
    }
}
