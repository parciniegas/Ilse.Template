using Ilse.Repository.Contracts;
using Ilse.Start.Domain.ToDo;

namespace Ilse.Start.Infrastructure.Repository.ToDo;

public class ToDo(string title, string? description): IAuditedEntity
{
    public int Id { get; init; }
    public  string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public ICollection<Tag> Tags { get; set; } = [];
    public List<Note> Notes { get; set; } = [];
    public Category? Category { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? CompletedNotes { get; set; }
    public bool IsDone => CompletedAt != null;
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public ToDoItem GetToDoItem() =>
        new ToDoItem(Title, Description ?? string.Empty, CompletedAt, CompletedNotes,
                        Tags.Select(t => new Domain.ToDo.Tag(t.Name, t.Value)).ToList())
                        {
                            Id = Id,
                            Notes = Notes.Select(n => new Domain.ToDo.Note(n.Text, n.CreatedAt)).ToList(),
                            CompletedNotes = CompletedNotes
                        };
}

public record Tag(string Name, string Value);
public record Note(string Text, DateTime CreatedAt);
