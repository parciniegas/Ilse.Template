using Ilse.Start.Common;

namespace Ilse.Start.Domain.ToDo;

public class ToDoItem(string title, string? description, List<Tag>? tags = null)
{
    private static readonly ToDoItem Empty = new("Empty", "Empty");

    public ToDoItem(string title, string? description, DateTime? completedAt, string? completedNotes, List<Tag>? tags = null)
        : this(title, description)
    {
        CompletedAt = completedAt;
        CompletedNotes = completedNotes;
        Tags = tags ?? [];
    }

    public ToDoItem(int id, string title, string description,
        DateTime createdAt, DateTime? completedAt, string? completedNotes, bool isDone)
        : this(title, description, completedAt, completedNotes)
    {
        Id = id;
        CreatedAt = createdAt;
        IsDone = isDone;
    }


    public int Id { get; init; }
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public List<Tag> Tags { get; set; } = [];
    public List<Note> Notes { get; set; } = [];
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? CompletedAt { get; private set; }
    public string? CompletedNotes { get; set; }
    public int ToDoCategoryId { get; set; }
    public ToDoCategory? ToDoCategory { get; set; }
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

    public static ToDoItem GetNull()
    {
        return Empty;
    }
}

public record Tag(string Name, string Value);

public record Note(string Text, DateTime CreatedAt);
