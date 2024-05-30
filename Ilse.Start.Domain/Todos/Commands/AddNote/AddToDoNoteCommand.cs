using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Todos.Commands.AddNote;

public record AddToDoNoteCommand(int TodoId, string Note) : BaseCommand;

public record AddToDoNoteCommandResponse(Todo Item)
{
    public static AddToDoNoteCommandResponse FromItem(Todo item)
    {
        return new AddToDoNoteCommandResponse(item);
    }
}
