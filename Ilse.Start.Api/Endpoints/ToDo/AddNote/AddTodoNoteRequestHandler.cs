using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi.EndPoints;
using Ilse.Start.Api.Config;
using Ilse.Start.Application.Todos.Commands.AddNote;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ilse.Start.Api.Endpoints.ToDo.AddNote;

public class AddTodoNoteRequestHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut($"/{Resources.Todos}/{{id:int}}/addnote", HandleAsync)
            .RequireAuthorization(Policies.TodoAddNote)
            .WithTags(Groups.Todos);
    }

    private static async Task<Results<Accepted, BadRequest<ProblemDetails>>>
        HandleAsync(ICommandDispatcher commandDispatcher,
            IContextAccessor<CorrelationContext> contextAccessor,
            int id,
            AddNoteRequest request)
    {
        var command = request.GetAppAddToDoNoteCommand(id);
        var result =
            await commandDispatcher.ExecAsync<AppAddTodoNoteCommand, OperationResult<AppAddTodoNoteCommandResponse>>(command);
        if (result.IsSuccess)
            return TypedResults.Accepted($"/todos/{id}");

        return TypedResults.BadRequest(result.ProblemDetails(contextAccessor.Context!.CorrelationId));
    }
}
