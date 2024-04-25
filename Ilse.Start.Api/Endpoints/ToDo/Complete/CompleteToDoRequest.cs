using Ilse.Start.Application.ToDo.Commands.Complete;

namespace Ilse.Start.Api.Endpoints.ToDo.Complete;

public record CompleteToDoRequest(int Id, string? Notes = null)
{
    internal AppCompleteToDoCommand GetAppCompleteToDoCommand()
    {
        return new AppCompleteToDoCommand(Id, Notes);
    }
}
