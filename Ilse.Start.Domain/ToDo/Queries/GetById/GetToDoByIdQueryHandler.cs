using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Errors;

namespace Ilse.Start.Domain.ToDo.Queries.GetById;

public class GetToDoByIdQueryHandler(IToDoRepository repository)
: IQueryHandler<GetToDoByIdQuery, OperationResult<GetTodoByIdQueryResponse>>
{
    public async Task<OperationResult<GetTodoByIdQueryResponse>> HandleAsync(
        GetToDoByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var todo = await repository.GetByIdAsync(query.Id);
        return todo.IsNull()
            ? ToDoErrors.ToDoNotFound(query.Id)
            : GetTodoByIdQueryResponse.FromToDoItem(todo);
    }
}
