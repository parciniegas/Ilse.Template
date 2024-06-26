using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos.Queries.GetAll;

namespace Ilse.Start.Application.Todos.Queries.GetAll;

public class AppGetAllToDosQueryHandler(IQueryDispatcher queryDispatcher)
    : IQueryHandler<AppGetAllToDosQuery, Result<AppGetAllTodosQueryResponse>>
{
    public async Task<Result<AppGetAllTodosQueryResponse>>
        HandleAsync(AppGetAllToDosQuery query, CancellationToken cancellationToken = new())
    {
        var domainQuery = AppGetAllToDosQuery.GetAllToDosQuery();
        var todos =
            await queryDispatcher.QueryAsync<GetAllToDosQuery, Result<GetAllToDosQueryResponse>>(domainQuery, cancellationToken);
        if (todos.IsFailure)
            return todos.Error!;
        return AppGetAllTodosQueryResponse.FromToDos(todos.Value!.ToDoItems);
    }
}
