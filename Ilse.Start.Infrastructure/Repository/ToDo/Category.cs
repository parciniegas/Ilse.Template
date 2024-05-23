namespace Ilse.Start.Infrastructure.Repository.ToDo;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<ToDo> Todos { get; set; } = [];
}
