using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetAll;

namespace Ilse.Start.Application.Todos.Queries.GetAll;

public class AppGetAllToDosQueryHandler(IQueryDispatcher queryDispatcher)
    : IQueryHandler<AppGetAllToDosQuery, OperationResult<AppGetAllTodosQueryResponse>>
{
    public async Task<OperationResult<AppGetAllTodosQueryResponse>>
        HandleAsync(AppGetAllToDosQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainQuery = AppGetAllToDosQuery.GetAllToDosQuery();
        var todos =
            await queryDispatcher.QueryAsync<GetAllToDosQuery, OperationResult<GetAllToDosQueryResponse>>(domainQuery, cancellationToken);
        if (todos.IsFailure)
            return todos.Error!;
        return AppGetAllTodosQueryResponse.FromToDos(todos.Value!.ToDoItems);
    }
}
