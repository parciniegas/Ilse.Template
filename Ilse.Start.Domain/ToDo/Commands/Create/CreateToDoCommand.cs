using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Create;

public record CreateToDoCommand(string Title, string? Description = null, List<Tag>? Tags = null) : ICommand
{
    public ToDoItem GetTodo()
    {
        var todo = new ToDoItem(Title, Description)
        {
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
