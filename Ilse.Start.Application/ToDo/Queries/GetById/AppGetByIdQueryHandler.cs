using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Queries.GetById;

namespace Ilse.Start.Application.ToDo.Queries.GetById;

public class AppGetByIdQueryHandler(IQueryDispatcher queryDispatcher):
    IQueryHandler<AppGetByIdQuery, OperationResult<AppGetToDoByIdQueryResponse>>
{
    public async Task<OperationResult<AppGetToDoByIdQueryResponse>>
        HandleAsync(AppGetByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var response =
            await queryDispatcher.QueryAsync<GetToDoByIdQuery, OperationResult<GetTodoByIdQueryResponse>>(query, cancellationToken);

        return response.IsSuccess
            ? AppGetToDoByIdQueryResponse.FromBase(response.Value!)
            : response.Error!;
    }
}
