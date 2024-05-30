using Ilse.Core.Context;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.GetByStatusAndDate;

public class GetByStatusAndDateHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet($"{Resources.Todos}/by_status_and_date/", HandleAsync)
            //.RequireAuthorization(Policies.TodoRead)
            .WithTags(Groups.Todos);
    }

private static async Task<Results<
        Ok<GetByStatusAndDateRequest>,
        BadRequest<ProblemDetails>>>
        HandleAsync(IContextAccessor<CorrelationContext> contextAccessor,
            IQueryDispatcher queryDispatcher,
            [AsParameters] GetByStatusAndDateRequest request)
    {
        // var query = AppGetToDosByStatusAndDateQuery.FromStatusAndDate(request.Status, request.CreatedAt);
        // var result =
        //     await queryDispatcher
        //         .QueryAsync<AppGetToDosByStatusAndDateQuery, OperationResult<AppGetToDosByStatusAndDateResponse>>(query);
        // if (result.IsFailure)
        //     return TypedResults.BadRequest(result.ProblemDetails(contextAccessor.Context!.CorrelationId));
        // var todos = result.Value!.ToDoItems.Select(ToDoDto.FromToDoItem).ToArray();

        return await Task.FromResult(TypedResults.Ok(request));
    }
}
