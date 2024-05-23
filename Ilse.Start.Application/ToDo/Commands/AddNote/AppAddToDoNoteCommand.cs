using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Commands.AddNote;

namespace Ilse.Start.Application.ToDo.Commands.AddNote;

public record AppAddToDoNoteCommand(int TodoId, string Note) : ICommand
{
    public AddToDoNoteCommand ToDomainCommand()
    {
        return new AddToDoNoteCommand(TodoId, Note);
    }
}


public record AppAddToDoNoteCommandResponse(ToDoItem Item)
{
    public static AppAddToDoNoteCommandResponse FromItem(ToDoItem item)
    {
        return new AppAddToDoNoteCommandResponse(item);
    }
}
