using Ilse.Start.Domain.Categories;

namespace Ilse.Start.Domain.Todos;

public class Todo(DateTime? completedAt)
{
    public Todo() : this(null)
    {
    }

    private static readonly Todo Empty = new() { Title = "Empty", Description = "Empty"};

    public int Id { get; init; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public List<Tag> Tags { get; init; } = [];
    public List<Note> Notes { get; init; } = [];
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? CompletedAt { get; private set; } = completedAt;
    public string? CompletedNotes { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool IsDone { get; private set; }

    public void Complete(string? notes = null)
    {
        IsDone = true;
        CompletedAt = DateTime.Now;
        CompletedNotes = notes;
    }

    public bool IsNull()
    {
        return Title == Empty.Title && Description == Empty.Description;
    }

    public static Todo GetNull()
    {
        return Empty;
    }
}

public record Tag(string Name, string Value);

public record Note(string Text, DateTime CreatedAt);
