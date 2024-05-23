using Ilse.MinimalApi.EndPoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.GetByStatusAndDate;

public class GetByDateAndStatusHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet(
            $"{{Resources.ToDos}}/by_status_and_date/{{status:bool}}/{{createdAt:datetime}}",
            HandleAsync);
    }

    private static async Task<Results<
        Ok<GetByStatusAndDateRequest>,
        BadRequest<ProblemDetails>>>
        HandleAsync([AsParameters] GetByStatusAndDateRequest request)
    {
        return await Task.FromResult(TypedResults.Ok(request));
    }
}
