using Ilse.Start.Application.ToDo.Commands.Complete;

namespace Ilse.Start.Api.Endpoints.ToDo.Complete;

public record CompleteToDoRequest(string? Notes = null)
{
    internal AppCompleteToDoCommand GetAppCompleteToDoCommand(int id)
    {
        return new AppCompleteToDoCommand(id, Notes);
    }
}
