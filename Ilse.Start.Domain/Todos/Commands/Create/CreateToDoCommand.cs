using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Todos.Commands.Create;

public record CreateToDoCommand(string Title, int CategoryId, string? Description = null, List<Tag>? Tags = null) : ICommand
{
    public Todo GetTodo()
    {
        var todo = new Todo
        {
            Title = Title,
            CategoryId = CategoryId,
            Description = Description,
            Tags = Tags ?? []
        };
        return todo;
    }
}

public record CreateToDoCommandResponse(int Id)
{
    public static CreateToDoCommandResponse FromId(int id)
    {
        return new CreateToDoCommandResponse(id);
    }
}
