using Ilse.Core.Results;
using Ilse.Cqrs.Queries;

namespace Ilse.Start.Domain.Todos.Queries.GetAll;

public class GetAllToDosQueryHandler(ITodoRepository repository)
    : IQueryHandler<GetAllToDosQuery, Result<GetAllToDosQueryResponse>>
{
    public async Task<Result<GetAllToDosQueryResponse>>
        HandleAsync(GetAllToDosQuery query, CancellationToken cancellationToken = new())
    {
        var todos = await repository.GetAllAsync();
        return GetAllToDosQueryResponse.FromToDos(todos);
    }
}
