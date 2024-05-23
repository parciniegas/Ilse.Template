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
        return endpoints.MapPut($"/{Resources.ToDos}/{{id:int}}/complete", HandleAsync)
            .RequireAuthorization(Policies.TodoComplete)
            .WithTags(Groups.Todo);
    }

    private static async Task<Results<Accepted, BadRequest<ProblemDetails>>>
        HandleAsync(ICommandDispatcher commandDispatcher,
            IContextAccessor<CorrelationContext> contextAccessor,
            int id,
            CompleteToDoRequest request)
    {
        var command = request.GetAppCompleteToDoCommand(id);
        var result =
            await commandDispatcher.ExecAsync<AppCompleteToDoCommand, OperationResult<AppCompleteToDoCommandResponse>>(command);
        if (result.IsSuccess)
            return TypedResults.Accepted($"/todos/{id}");

        return TypedResults.BadRequest(result.ProblemDetails(contextAccessor.Context!.CorrelationId));
    }
}
