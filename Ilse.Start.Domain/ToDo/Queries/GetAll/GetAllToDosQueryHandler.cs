using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.ToDo.Queries.GetAll;

public class GetAllToDosQueryHandler(IToDoRepository repository)
    : IQueryHandler<GetAllToDosQuery, OperationResult<GetAllToDosQueryResponse>>
{
    public async Task<OperationResult<GetAllToDosQueryResponse>>
        HandleAsync(GetAllToDosQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var todos = await repository.GetAllAsync();
        return GetAllToDosQueryResponse.FromToDos(todos);
    }
}
