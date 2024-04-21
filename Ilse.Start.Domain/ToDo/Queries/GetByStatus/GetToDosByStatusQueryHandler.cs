using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace Ilse.Start.Domain.ToDo.Queries.GetByStatus;

public class GetToDosByStatusQueryHandler(IRepository repository)
: IQueryHandler<GetToDosByStatusQuery, OperationResult<GetToDosByStatusQueryResponse>>
{
    public async Task<OperationResult<GetToDosByStatusQueryResponse>> 
        HandleAsync(GetToDosByStatusQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var todos = await 
            repository.GetByAsync<ToDoItem>(t => t.IsDone == query.IsDone, cancellationToken);
        var list = todos.ToList();

        return GetToDosByStatusQueryResponse.FromToDoItem(list);
    }
}