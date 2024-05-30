using Ilse.Start.Application.Todos.Commands.AddNote;

namespace Ilse.Start.Api.Endpoints.ToDo.AddNote;

public record AddNoteRequest(string Note)
{
    internal AppAddTodoNoteCommand GetAppAddToDoNoteCommand(int id)
    {
        return new AppAddTodoNoteCommand(id, Note);
    }
}
