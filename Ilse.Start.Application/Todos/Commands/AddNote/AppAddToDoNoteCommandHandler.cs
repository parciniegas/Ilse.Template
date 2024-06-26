using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos.Commands.AddNote;

namespace Ilse.Start.Application.Todos.Commands.AddNote;

public class AppAddToDoNoteCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppAddTodoNoteCommand, Result<AppAddTodoNoteCommandResponse>>
{
    public async Task<Result<AppAddTodoNoteCommandResponse>>
        HandleAsync(AppAddTodoNoteCommand command, CancellationToken cancellationToken = new())
    {
        var domainCommand = command.ToDomainCommand();
        var result = await commandDispatcher.ExecAsync<AddToDoNoteCommand, Result<AppAddTodoNoteCommandResponse>>(domainCommand, cancellationToken);
        return AppAddTodoNoteCommandResponse.FromItem(result.Value!.Item);
    }
}
