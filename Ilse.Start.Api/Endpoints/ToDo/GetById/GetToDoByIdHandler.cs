using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Api.Endpoints.ToDo.Dto;
using Ilse.Start.Application.ToDo.Queries.GetById;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.GetById;

public class GetToDoByIdHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet($"/{Resources.ToDos}/{{id:int}}", HandleAsync)
            .RequireAuthorization(Policies.TodoRead)
            .WithTags(Resources.ToDos);
    }

    private static async Task<Results<
        Ok<ToDoDto>,
        BadRequest<ProblemDetails>>>
    HandleAsync(
        IContextAccessor<CorrelationContext> contextAccessor,
        IQueryDispatcher queryDispatcher,
        int id)
    {
        var query = AppGetToDoByIdQuery.FromId(id);
        var result =
            await queryDispatcher.QueryAsync<AppGetToDoByIdQuery, OperationResult<AppGetToDoByIdQueryResponse>>(query);
        if (result.IsSuccess)
            return TypedResults.Ok(ToDoDto.FromToDoItem(result.Value!.ToDoItem));
        return TypedResults.BadRequest(
            result.ProblemDetails(contextAccessor.Context!.CorrelationId));
    }
}
