using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Api.Endpoints.ToDo.Dto;
using Ilse.Start.Application.ToDo.Queries.GetByStatus;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.GetByStatus;

public class GetToDosByStatusHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet($"{Resources.ToDos}/by_status/{{status:bool}}", HandleAsync)
            .RequireAuthorization(Policies.TodoRead)
            .WithTags(Resources.ToDos);
    }

    private async Task<Results<
        Ok<ToDoDto[]>,
        BadRequest<ProblemDetails>>>
        HandleAsync(IContextAccessor<CorrelationContext> contextAccessor,
            IQueryDispatcher queryDispatcher,
            bool status)
    {
        var query = AppGetToDosByStatusQuery.FromStatus(status);
        var result =
            await queryDispatcher
                .QueryAsync<AppGetToDosByStatusQuery, OperationResult<AppGetToDosByStatusResponse>>(query);
        if (result.IsFailure)
            return TypedResults.BadRequest(result.ProblemDetails(contextAccessor.Context!.CorrelationId));
        var todos = result.Value!.ToDoItems.Select(ToDoDto.FromToDoItem).ToArray();
        return TypedResults.Ok(todos);

    }
}
