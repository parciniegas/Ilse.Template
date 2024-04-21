using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Application.ToDo.Commands.Create;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.Create;

public class CreateToDoRequestHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/todos", HandleAsync)
            .RequireAuthorization("todo.create")
            .WithTags("ToDo");
    }

    private static async Task<Results<
            Created<CreateToDoRequestResponse>,
            BadRequest<ProblemDetails>,
            Conflict<ProblemDetails>>>
        HandleAsync(
            ILogger<CreateToDoRequestHandler> logger,
            IContextAccessor<CorrelationContext> correlationAccessor,
            CreateToDoRequest request,
            ICommandDispatcher commandDispatcher)
    {
        var result =
            await commandDispatcher.ExecAsync<AppCreateToDoCommand, OperationResult<AppCreateToDoCommandResponse>>(request.CreateToDoCommand());
        if (result.IsSuccess)
            return TypedResults.Created($"/todos/{result.Value!.Id}", new CreateToDoRequestResponse(result.Value!.Id));

        var problemDetails = result.ProblemDetails(correlationAccessor.Context!.CorrelationId);
        logger.LogError(problemDetails.ToJson());
        return result.ErrorType switch
        {
            ErrorType.BadRequest => TypedResults.BadRequest(problemDetails),
            ErrorType.Conflict => TypedResults.Conflict(problemDetails),
            _ => TypedResults.BadRequest(problemDetails)
        };
    }
}