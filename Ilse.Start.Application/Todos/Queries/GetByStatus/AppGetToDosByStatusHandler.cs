using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos.Queries.GetByStatus;

namespace Ilse.Start.Application.Todos.Queries.GetByStatus;

public class AppGetToDosByStatusHandler(IQueryDispatcher queryDispatcher)
    : IQueryHandler<AppGetToDosByStatusQuery, Result<AppGetToDosByStatusResponse>>
{
    public async Task<Result<AppGetToDosByStatusResponse>>
        HandleAsync(AppGetToDosByStatusQuery query, CancellationToken cancellationToken = new())
    {
        var domainQuery = AppGetToDosByStatusQuery.GetToDoByStatusQuery(query.IsComplete);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDosByStatusQuery, Result<GetToDosByStatusQueryResponse>>(domainQuery, cancellationToken);
        return AppGetToDosByStatusResponse.FromToDoItem(response.Value!.ToDoItems);
    }
}
