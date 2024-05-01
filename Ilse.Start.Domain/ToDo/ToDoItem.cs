using Ilse.Start.Common;

namespace Ilse.Start.Domain.ToDo;

public class ToDoItem(string title, string? description)
{
    private static readonly ToDoItem Empty = new("Empty", "Empty");

    public ToDoItem(string title, string? description, DateTime? completedAt, string? notes)
        : this(title, description)
    {
        CompletedAt = completedAt;
        CompletedNotes = notes;
    }

    public ToDoItem(int id, string title, string description,
        DateTime createdAt, DateTime? completedAt, string? notes, bool isDone)
        : this(title, description, completedAt, notes)
    {
        Id = id;
        CreatedAt = createdAt;
        IsDone = isDone;
    }


    public int Id { get; init; }
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? CompletedAt { get; private set; }
    public string? CompletedNotes { get; private set; }
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
