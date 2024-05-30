using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetByStatus;

public class GetToDosByStatusQueryHandler(ITodoRepository repository)
: IQueryHandler<GetToDosByStatusQuery, OperationResult<GetToDosByStatusQueryResponse>>
{
    public async Task<OperationResult<GetToDosByStatusQueryResponse>>
        HandleAsync(GetToDosByStatusQuery query, CancellationToken cancellationToken = new())
    {
        var todos = await
            repository.GetByStatusAsync(query.IsCompleted);
        var list = todos.ToList();

        return GetToDosByStatusQueryResponse.FromToDoItem(list);
    }
}
