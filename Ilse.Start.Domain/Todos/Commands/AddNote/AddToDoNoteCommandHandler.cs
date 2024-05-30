using Ilse.Core.Results;
using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Todos.Commands.AddNote;

public class AddToDoNoteCommandHandler(ITodoRepository repository):
    ICommandHandler<AddToDoNoteCommand, OperationResult<AddToDoNoteCommandResponse>>
{
    public async Task<OperationResult<AddToDoNoteCommandResponse>>
        HandleAsync(AddToDoNoteCommand command, CancellationToken cancellationToken = new())
    {
        var todo = await repository.GetByIdAsync(command.TodoId);
        todo.Notes.Add(new Note(command.Note, DateTime.UtcNow));
        await repository.UpdateAsync(todo);
        return AddToDoNoteCommandResponse.FromItem(todo);
    }
}
