using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos.Queries.GetById;

namespace Ilse.Start.Application.Todos.Queries.GetById;

public class AppGetByIdQueryHandler(IQueryDispatcher queryDispatcher):
    IQueryHandler<AppGetTodoByIdQuery, Result<AppGetTodoByIdQueryResponse>>
{
    public async Task<Result<AppGetTodoByIdQueryResponse>>
        HandleAsync(AppGetTodoByIdQuery query, CancellationToken cancellationToken = new())
    {
        var domainQuery = AppGetTodoByIdQuery.GetToDoByIdQuery(query.Id);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDoByIdQuery, Result<GetTodoByIdQueryResponse>>(domainQuery, cancellationToken);

        return response.IsSuccess
            ? AppGetTodoByIdQueryResponse.FromDomainResponse(response.Value!)
            : response.Error!;
    }
}
