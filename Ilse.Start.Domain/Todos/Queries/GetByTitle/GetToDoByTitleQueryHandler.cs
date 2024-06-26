using Ilse.Core.Results;
using Ilse.Cqrs.Queries;
using Ilse.Start.Domain.Todos.Errors;

namespace Ilse.Start.Domain.Todos.Queries.GetByTitle;

public class GetToDoByTitleQueryHandler(ITodoRepository repository)
: IQueryHandler<GetToDoByTitleQuery, Result<GetToDoByTitleResponse>>
{
    public async Task<Result<GetToDoByTitleResponse>>
        HandleAsync(GetToDoByTitleQuery query, CancellationToken cancellationToken = new())
    {
        var todo = await repository.GetByTitleAsync(query.Title);
        return todo.IsNull()
            ? ToDoErrors.ToDoNotFound(query.Title)
            : GetToDoByTitleResponse.FromToDoItem(todo);
    }
}
