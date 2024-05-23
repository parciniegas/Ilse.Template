using Ilse.Core.Results;
using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.AddNote;

public class AddToDoNoteCommandHandler(IToDoRepository repository):
    ICommandHandler<AddToDoNoteCommand, OperationResult<AddToDoNoteCommandResponse>>
{
    public async Task<OperationResult<AddToDoNoteCommandResponse>>
        HandleAsync(AddToDoNoteCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var todo = await repository.GetByIdAsync(command.TodoId);
        todo.Notes.Add(new Note(command.Note, DateTime.UtcNow));
        await repository.UpdateAsync(todo);
        return AddToDoNoteCommandResponse.FromItem(todo);
    }
}
