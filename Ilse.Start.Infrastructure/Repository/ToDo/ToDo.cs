namespace Ilse.Start.Infrastructure.Repository.ToDo;

public class ToDo(int id, string todoTitle, string? todoDescription, 
    DateTime createdAt, DateTime? completedAt, string? notes)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = todoTitle;
    public string? Description { get; set; } = todoDescription;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? CompletedAt { get; set; }
    public string? Notes { get; set; }
    public bool IsDone { get; set; }
}