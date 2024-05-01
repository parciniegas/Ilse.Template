using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetByTitle;

namespace Ilse.Start.Application.ToDo.Queries.GetByTitle;

public class GetToDoByTitleHandler(IQueryDispatcher queryDispatcher)

    : IQueryHandler<AppGetToDoByTitleQuery, OperationResult<AppGetToDoByTitleResponse>>
{
    public async Task<OperationResult<AppGetToDoByTitleResponse>>
        HandleAsync(AppGetToDoByTitleQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainQuery = AppGetToDoByTitleQuery.FromTitle(query.Tittle);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDoByTitleQuery, OperationResult<GetToDoByTitleResponse>>(domainQuery, cancellationToken);
        if (response.IsSuccess)
            return AppGetToDoByTitleResponse.FromDomainResponse(response.Value!);
        return response.Error!;
    }
}
