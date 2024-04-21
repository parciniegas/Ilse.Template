namespace Ilse.Start.Infrastructure.ToDo;

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; }
    public string? Notes { get; set; }
}