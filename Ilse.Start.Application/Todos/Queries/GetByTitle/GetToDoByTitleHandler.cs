using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos.Queries.GetByTitle;

namespace Ilse.Start.Application.Todos.Queries.GetByTitle;

public class GetToDoByTitleHandler(IQueryDispatcher queryDispatcher)

    : IQueryHandler<AppGetToDoByTitleQuery, OperationResult<AppGetToDoByTitleResponse>>
{
    public async Task<OperationResult<AppGetToDoByTitleResponse>>
        HandleAsync(AppGetToDoByTitleQuery query, CancellationToken cancellationToken = new())
    {
        var domainQuery = AppGetToDoByTitleQuery.GetToDoByTitleQuery(query.Tittle);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDoByTitleQuery, OperationResult<GetToDoByTitleResponse>>(domainQuery, cancellationToken);
        if (response.IsSuccess)
            return AppGetToDoByTitleResponse.FromDomainResponse(response.Value!);
        return response.Error!;
    }
}
