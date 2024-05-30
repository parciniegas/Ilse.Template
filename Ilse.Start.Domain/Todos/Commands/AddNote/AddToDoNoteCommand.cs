using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Domain.ToDo.Commands.AddNote;

public record AddToDoNoteCommand(int TodoId, string Note) : BaseCommand;

public record AddToDoNoteCommandResponse(Todo Item)
{
    public static AddToDoNoteCommandResponse FromItem(Todo item)
    {
        return new AddToDoNoteCommandResponse(item);
    }
}
