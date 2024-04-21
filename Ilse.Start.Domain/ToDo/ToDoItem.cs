namespace Ilse.Start.Domain.ToDo;

public class ToDoItem(string title, string? description)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? CompletedAt { get; private set; }
    public string? CompletedNotes { get; set; }
    public bool IsDone { get; set; }
    
    public void Complete(string? notes = null)
    {
        IsDone = true;
        CompletedAt = DateTime.Now;
        CompletedNotes = notes;
    }
}