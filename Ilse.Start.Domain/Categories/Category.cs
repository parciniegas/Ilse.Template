using Ilse.Start.Domain.ToDo;
using Ilse.Start.Domain.Todos;

namespace Ilse.Start.Domain.Categories;

public class Category
{
    private static readonly Category Empty = new Category {
        Name = "Empty", Description = "Empty"
    };

    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Todo> Todos { get; set; } = [];

    public static Category GetNull()
    {
        return Empty;
    }

    public bool IsNull()
    {
        return Name == Empty.Name && Description == Empty.Description;
    }
}
