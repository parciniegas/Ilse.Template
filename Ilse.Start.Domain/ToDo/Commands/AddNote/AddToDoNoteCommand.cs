using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.AddNote;

public record AddToDoNoteCommand(int TodoId, string Note) : BaseCommand;

public record AddToDoNoteCommandResponse(ToDoItem Item)
{
    public static AddToDoNoteCommandResponse FromItem(ToDoItem item)
    {
        return new AddToDoNoteCommandResponse(item);
    }
}
