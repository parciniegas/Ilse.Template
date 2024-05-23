namespace Ilse.Start.Domain.ToDo;

public class ToDoCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<ToDoItem> ToDoItems { get; set; } = [];
}
