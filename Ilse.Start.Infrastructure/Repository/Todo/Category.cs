using Ilse.Repository.Abstracts;
using Ilse.Repository.Contracts;

namespace Ilse.Start.Infrastructure.Repository.Todo;

public class Category: BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Todo?> Todos { get; set; } = [];

    public Domain.Categories.Category GetDomainCategory() => new()
    {
        Id = Id,
        Name = Name,
        Description = Description,
        Todos = Todos.Select(t => t!.GetTodo()).ToList()
    };
}
