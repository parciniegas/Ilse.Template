using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;
using Ilse.Start.Domain.ToDo.Errors;

namespace Ilse.Start.Domain.ToDo.Queries.GetById;

public class GetToDoByIdQueryHandler(IRepository repository)
: IQueryHandler<GetToDoByIdQuery, OperationResult<GetTodoByIdQueryResponse>>
{
    public async Task<OperationResult<GetTodoByIdQueryResponse>> HandleAsync(
        GetToDoByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var todo = await repository.GetByIdAsync<ToDoItem, int>(query.Id, cancellationToken);
        return todo is null 
            ? ToDoErrors.ToDoNotFound(query.Id) 
            : GetTodoByIdQueryResponse.FromToDoItem(todo);
    }
}