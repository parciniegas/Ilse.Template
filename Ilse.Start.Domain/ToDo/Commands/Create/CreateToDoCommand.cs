using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Create;

public record CreateToDoCommand(string Title, string? Description = null) : ICommand
{
    public ToDoItem GetTodo(int id)
    {
        return new ToDoItem(Title, Description) {Id = id};
    }
}

public record CreateTodoCommandResponse(int Id)
{
    public static CreateTodoCommandResponse FromId(int id)
    {
        return new CreateTodoCommandResponse(id);
    }
}