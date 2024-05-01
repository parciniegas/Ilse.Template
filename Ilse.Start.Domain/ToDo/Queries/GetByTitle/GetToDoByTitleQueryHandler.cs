using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.ToDo.Errors;

namespace Ilse.Start.Domain.ToDo.Queries.GetByTitle;

public class GetToDoByTitleQueryHandler(IToDoRepository repository)
: IQueryHandler<GetToDoByTitleQuery, OperationResult<GetToDoByTitleResponse>>
{
    public async Task<OperationResult<GetToDoByTitleResponse>>
        HandleAsync(GetToDoByTitleQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var todo = await repository.GetByTitleAsync(query.Title);
        return todo.IsNull()
            ? ToDoErrors.ToDoNotFound(query.Title)
            : GetToDoByTitleResponse.FromToDoItem(todo);
    }
}
