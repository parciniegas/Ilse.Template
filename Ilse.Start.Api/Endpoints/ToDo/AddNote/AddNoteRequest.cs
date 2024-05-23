using Ilse.Start.Application.ToDo.Commands.AddNote;

namespace Ilse.Start.Api.Endpoints.ToDo.AddNote;

public record AddNoteRequest(string Note)
{
    internal AppAddToDoNoteCommand GetAppAddToDoNoteCommand(int id)
    {
        return new AppAddToDoNoteCommand(id, Note);
    }
}
