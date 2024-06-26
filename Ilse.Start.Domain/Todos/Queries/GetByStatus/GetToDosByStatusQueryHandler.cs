using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetByStatus;

public class GetToDosByStatusQueryHandler(ITodoRepository repository)
: IQueryHandler<GetToDosByStatusQuery, Result<GetToDosByStatusQueryResponse>>
{
    public async Task<Result<GetToDosByStatusQueryResponse>>
        HandleAsync(GetToDosByStatusQuery query, CancellationToken cancellationToken = new())
    {
        var todos = await
            repository.GetByStatusAsync(query.IsCompleted);
        var list = todos.ToList();

        return GetToDosByStatusQueryResponse.FromToDoItem(list);
    }
}
