using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Domain.ToDo.Commands.AddNote;

public class AddToDoNoteCommandHandler(ITodoRepository repository):
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
