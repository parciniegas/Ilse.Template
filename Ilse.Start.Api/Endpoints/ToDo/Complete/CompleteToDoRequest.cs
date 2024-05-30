using Ilse.Start.Application.Todos.Commands.Complete;

namespace Ilse.Start.Api.Endpoints.ToDo.Complete;

public record CompleteToDoRequest(string? Notes = null)
{
    internal AppCompleteTodoCommand GetAppCompleteToDoCommand(int id)
    {
        return new AppCompleteTodoCommand(id, Notes);
    }
}
