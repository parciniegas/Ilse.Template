using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Api.Endpoints.ToDo.Dto;
using Ilse.Start.Application.Todos.Queries.GetByTitle;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.GetByTitle;

public class GetToDoByTitleHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet($"{Resources.Todos}/by_title/{{title}}", HandleAsync)
            .RequireAuthorization(Policies.TodoRead)
            .WithTags(Groups.Todos);
    }

    private static async Task<Results<
        Ok<ToDoDto>,
        BadRequest<ProblemDetails>>>
        HandleAsync(IContextAccessor<CorrelationContext> contextAccessor,
            IQueryDispatcher queryDispatcher,
            string title)
    {
                var query = AppGetToDoByTitleQuery.FromTitle(title);
        var result =
            await queryDispatcher
                .QueryAsync<AppGetToDoByTitleQuery, OperationResult<AppGetToDoByTitleResponse>>(query);
        if (result.IsFailure)
            return TypedResults.BadRequest(result.ProblemDetails(contextAccessor.Context!.CorrelationId));
        var todos = ToDoDto.FromToDoItem(result.Value!.Todo);
        return TypedResults.Ok(todos);
    }
}
