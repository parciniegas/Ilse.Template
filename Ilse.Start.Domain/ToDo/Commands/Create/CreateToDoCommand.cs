using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Create;

public record CreateToDoCommand(string Title, string? Description = null) : ICommand
{
    public ToDoItem GetTodo()
    {
        var todo = new ToDoItem(Title, Description)
        {
            CreatedAt = DateTime.Now
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