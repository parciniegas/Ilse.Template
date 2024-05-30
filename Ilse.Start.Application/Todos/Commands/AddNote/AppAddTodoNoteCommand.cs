using Ilse.Cqrs.Commands;
using Ilse.Start.Domain.ToDo.Commands.AddNote;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Application.Todos.Commands.AddNote;

public record AppAddTodoNoteCommand(int TodoId, string Note) : ICommand
{
    public AddToDoNoteCommand ToDomainCommand()
    {
        return new AddToDoNoteCommand(TodoId, Note);
    }
}


public record AppAddTodoNoteCommandResponse(Todo Item)
{
    public static AppAddTodoNoteCommandResponse FromItem(Todo item)
    {
        return new AppAddTodoNoteCommandResponse(item);
    }
}
