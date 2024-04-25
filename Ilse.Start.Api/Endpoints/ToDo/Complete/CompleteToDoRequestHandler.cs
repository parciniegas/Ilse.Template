using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Application.ToDo.Commands.Complete;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.Complete;

public class CompleteToDoRequestHandler : IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/todos/{id}/complete", HandleAsync)
            .RequireAuthorization(Policies.TodoComplete)
            .WithTags("");
    }

    private static async Task<Results<Accepted, BadRequest<ProblemDetails>>>
        HandleAsync(ICommandDispatcher commandDispatcher,
            IContextAccessor<CorrelationContext> contextAccessor,
            CompleteToDoRequest request)
    {
        var command = request.GetAppCompleteToDoCommand();
        var result =
            await commandDispatcher.ExecAsync<AppCompleteToDoCommand, OperationResult<AppCompleteToDoCommandResponse>>(command);
        if (result.IsSuccess)
            return TypedResults.Accepted($"/todos/{request.Id}");

        return TypedResults.BadRequest(result.ProblemDetails(contextAccessor.Context!.CorrelationId));
    }
}
