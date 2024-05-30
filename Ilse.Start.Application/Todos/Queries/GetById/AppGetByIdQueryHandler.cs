using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos.Queries.GetById;

namespace Ilse.Start.Application.Todos.Queries.GetById;

public class AppGetByIdQueryHandler(IQueryDispatcher queryDispatcher):
    IQueryHandler<AppGetTodoByIdQuery, OperationResult<AppGetTodoByIdQueryResponse>>
{
    public async Task<OperationResult<AppGetTodoByIdQueryResponse>>
        HandleAsync(AppGetTodoByIdQuery query, CancellationToken cancellationToken = new())
    {
        var domainQuery = AppGetTodoByIdQuery.GetToDoByIdQuery(query.Id);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDoByIdQuery, OperationResult<GetTodoByIdQueryResponse>>(domainQuery, cancellationToken);

        return response.IsSuccess
            ? AppGetTodoByIdQueryResponse.FromDomainResponse(response.Value!)
            : response.Error!;
    }
}
