using Ilse.Cqrs.Commands;

namespace Ilse.Start.Applicaction.ToDo.Commands.Create;

public class AppCreateToDoCommandHandler
    : ICommandHandler<AppCreateToDoCommand, AppCreateToDoCommandResponse>
{
    public Task<AppCreateToDoCommandResponse> 
        HandleAsync(AppCreateToDoCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        P@throw new NotImplementedException();
    }
}
