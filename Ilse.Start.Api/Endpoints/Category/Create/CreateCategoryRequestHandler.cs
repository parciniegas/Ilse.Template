using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Application.Categories.Commands.Create;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.Category.Create;

public class CreateCategoryRequestHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost($"/{Resources.Categories}", HandleAsync)
            //.RequireAuthorization(Policies.CategoryCreate)
            .WithTags(Groups.Categories);
    }

    private static async Task<Results<
        Created<CreateCategoryRequestResponse>,
        BadRequest<ProblemDetails>,
        Conflict<ProblemDetails>>> HandleAsync(
            ILogger<CreateCategoryRequestHandler> logger,
            IContextAccessor<CorrelationContext> correlationAccessor,
            CreateCategoryRequest request,
            ICommandDispatcher commandDispatcher)
    {
        var result =
            await commandDispatcher
                .ExecAsync<AppCreateCategoryCommand, OperationResult<AppCreateCategoryCommandResponse>>
                    (request.GetAppCreateCategoryCommand());
        if (result.IsSuccess)
            return TypedResults.Created($"{Resources.Categories}/{result.Value!.Id}",
                new CreateCategoryRequestResponse(result.Value!.Id));

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
