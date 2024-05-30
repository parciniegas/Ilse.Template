using Ilse.Cqrs.Commands;

namespace Ilse.Start.Domain.Categories.Commands.AddTodo;

public record AddTodoToCategoryCommand(int CategoryId, int TodoId): BaseCommand;

public record AddTodoToCategoryCommandResponse(int Id);
