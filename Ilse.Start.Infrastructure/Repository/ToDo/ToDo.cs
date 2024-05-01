using System.ComponentModel.DataAnnotations;
using Ilse.Start.Domain.ToDo;

namespace Ilse.Start.Infrastructure.Repository.ToDo;

public class ToDo(string title, string? description)
{
    public ToDo(int id, string title, string? description,
        DateTime createdAt, DateTime? completedAt, string? notes)
    : this(title, description)
    {
        Id = id;
    }

    public int Id { get; init; }
    [MaxLength(50)]
    public  string Title { get; init; } = title;

    [MaxLength(500)]
    public string? Description { get; init; } = description;

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; } = null;

    [MaxLength(1000)]
    public string? Notes { get; set; } = null;

    public bool IsDone => CompletedAt != null;

    public ToDoItem GetToDoItem() =>
        new ToDoItem(Id, Title, Description ?? string.Empty, CreatedAt, CompletedAt, Notes, IsDone);
}
