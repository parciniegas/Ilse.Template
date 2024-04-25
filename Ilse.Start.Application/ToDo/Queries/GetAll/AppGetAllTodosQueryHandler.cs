using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetAll;

namespace Ilse.Start.Application.ToDo.Queries.GetAll;

public class AppGetAllTodosQueryHandler(IQueryDispatcher queryDispatcher
    ): IQueryHandler<AppGetAllTodosQuery, OperationResult<AppGetAllTodosQueryResponse>>
{
    public async Task<OperationResult<AppGetAllTodosQueryResponse>>
        HandleAsync(AppGetAllTodosQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainQuery = query.GetAllTodosQuery();
        var todos =
            await queryDispatcher.QueryAsync<GetAllTodosQuery, OperationResult<GetAllTodosQueryResponse>>(domainQuery, cancellationToken);
        return AppGetAllTodosQueryResponse.FromToDos(todos.Value!.ToDoItems);
    }
}
