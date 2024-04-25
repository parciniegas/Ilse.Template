using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetAll;

public class GetAllTodosQueryHandler(IToDoRepository repository)
    : IQueryHandler<GetAllTodosQuery, OperationResult<GetAllTodosQueryResponse>>
{
    public async Task<OperationResult<GetAllTodosQueryResponse>>
        HandleAsync(GetAllTodosQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var todos = await repository.GetAllAsync();
        return GetAllTodosQueryResponse.FromToDos(todos);
    }
}
