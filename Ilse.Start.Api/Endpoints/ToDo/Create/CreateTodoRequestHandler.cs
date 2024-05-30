using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Application.Todos.Commands.Create;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.Create;

public class CreateTodoRequestHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost($"/{Resources.Todos}", HandleAsync)
            //.RequireAuthorization(Policies.TodoCreate)
            .WithTags(Groups.Todos);
    }

    private static async Task<Results<
            Created<CreateToDoRequestResponse>,
            BadRequest<ProblemDetails>,
            Conflict<ProblemDetails>>>
        HandleAsync(
            ILogger<CreateTodoRequestHandler> logger,
            IContextAccessor<CorrelationContext> correlationAccessor,
            CreateTodoRequest request,
            ICommandDispatcher commandDispatcher)
    {
        var result =
            await commandDispatcher.ExecAsync<AppCreateTodoCommand, OperationResult<AppCreateToDoCommandResponse>>(request.GetAppCreateToDoCommand());
        if (result.IsSuccess)
            return TypedResults.Created($"{Resources.Todos}/{result.Value!.Id}", new CreateToDoRequestResponse(result.Value!.Id));

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
