using Ilse.Start.Domain.ToDo;

namespace Ilse.Start.Domain.Categories;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<ToDoItem> ToDoItems { get; set; } = [];
}
