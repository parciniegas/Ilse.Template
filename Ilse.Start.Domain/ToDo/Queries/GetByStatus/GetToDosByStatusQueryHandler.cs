using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetByStatus;

public class GetToDosByStatusQueryHandler(IToDoRepository repository)
: IQueryHandler<GetToDosByStatusQuery, OperationResult<GetToDosByStatusQueryResponse>>
{
    public async Task<OperationResult<GetToDosByStatusQueryResponse>>
        HandleAsync(GetToDosByStatusQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var todos = await
            repository.GetByStatusAsync(query.IsCompleted);
        var list = todos.ToList();

        return GetToDosByStatusQueryResponse.FromToDoItem(list);
    }
}
