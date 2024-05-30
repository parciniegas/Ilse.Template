using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetByStatus;

namespace Ilse.Start.Application.Todos.Queries.GetByStatus;

public class AppGetToDosByStatusHandler(IQueryDispatcher queryDispatcher)
    : IQueryHandler<AppGetToDosByStatusQuery, OperationResult<AppGetToDosByStatusResponse>>
{
    public async Task<OperationResult<AppGetToDosByStatusResponse>>
        HandleAsync(AppGetToDosByStatusQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainQuery = AppGetToDosByStatusQuery.GetToDoByStatusQuery(query.IsComplete);
        var response =
            await queryDispatcher.QueryAsync
                <GetToDosByStatusQuery, OperationResult<GetToDosByStatusQueryResponse>>(domainQuery, cancellationToken);
        return AppGetToDosByStatusResponse.FromToDoItem(response.Value!.ToDoItems);
    }
}
