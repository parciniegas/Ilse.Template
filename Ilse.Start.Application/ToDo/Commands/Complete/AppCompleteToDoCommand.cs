using Ilse.Core.Results;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.ToDo.Commands.Complete;

namespace Ilse.Start.Application.ToDo.Commands.Complete;

public record AppCompleteToDoCommand(int Id, string? Notes = null) : CompleteTodoCommand(Id, Notes);

public record AppCompleteToDoCommandResponse(bool Completed)
{
    public static OperationResult<AppCompleteToDoCommandResponse> FromBool(bool completed)
    {
        return new AppCompleteToDoCommandResponse(completed);
    }
}
