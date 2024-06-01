using Ilse.Repository.Contracts;

namespace Ilse.Start.Infrastructure.Repository.Todo;

public class Todo(string title, int categoryId, string? description): IAuditedEntity
{
    public int Id { get; init; }
    public  string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public ICollection<Tag> Tags { get; set; } = [];
    public List<Note> Notes { get; set; } = [];
    public int CategoryId { get; set; } = categoryId;
    public Category? Category { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? CompletedNotes { get; set; }
    public bool IsDone => CompletedAt != null;
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public Domain.Todos.Todo GetTodo() => new(CompletedAt)
        {
            Id = Id,
            Title = Title,
            Description = Description,
            Tags = Tags.Select(t => new Domain.Todos.Tag(t.Name, t.Value)).ToList(),
            Notes = Notes.Select(n => new Domain.Todos.Note(n.Text, n.CreatedAt)).ToList(),
            CompletedNotes = CompletedNotes
        };
}

public record Tag(string Name, string Value);
public record Note(string Text, DateTime CreatedAt);
