using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Api.Endpoints.ToDo.Dto;

public record ToDoDto(
    int Id,
    string Title,
    string? Description,
    DateTime CreatedAt,
    DateTime? CompletedAt,
    string? CompletedNotes,
    bool IsCompleted)
{
    public static ToDoDto FromToDoItem(Todo todo)
    {
        return new ToDoDto(
            todo.Id,
            todo.Title,
            todo.Description,
            todo.CreatedAt,
            todo.CompletedAt,
            todo.CompletedNotes,
            todo.IsDone);
    }
}
