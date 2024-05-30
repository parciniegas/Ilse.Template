using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetById;

namespace Ilse.Start.Application.Todos.Queries.GetById;

public class AppGetByIdQueryHandler(IQueryDispatcher queryDispatcher):
    IQueryHandler<AppGetToDoByIdQuery, OperationResult<AppGetToDoByIdQueryResponse>>
{
    public async Task<OperationResult<AppGetToDoByIdQueryResponse>>
        HandleAsync(AppGetToDoByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainQuery = AppGetToDoByIdQuery.GetToDoByIdQuery(query.Id);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDoByIdQuery, OperationResult<GetTodoByIdQueryResponse>>(domainQuery, cancellationToken);

        return response.IsSuccess
            ? AppGetToDoByIdQueryResponse.FromDomainResponse(response.Value!)
            : response.Error!;
    }
}
