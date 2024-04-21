using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.ToDo.Commands.Complete;

public record CompleteTodoCommand(int Id, string? Notes = null) : BaseCommand;

public record CompleteTodoCommandResponse(ToDoItem Item)
{
    public static CompleteTodoCommandResponse FromItem(ToDoItem item)
    {
        return new CompleteTodoCommandResponse(item);
    }
}
