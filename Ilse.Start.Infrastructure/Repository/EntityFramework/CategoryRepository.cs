using Ilse.Repository.Contracts;
using Ilse.Start.Domain.Categories;
using Todo = Ilse.Start.Infrastructure.Repository.ToDo.Todo;
using Category = Ilse.Start.Infrastructure.Repository.ToDo.Category;

namespace Ilse.Start.Infrastructure.Repository.EntityFramework;

public class CategoryRepository(IRepository repository): ICategoryRepository
{
    public async Task<int> CreateAsync(Domain.Categories.Category category)
    {
        var entity = new Category
        {
            Name = category.Name,
            Description = category.Description
        };
        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Domain.Categories.Category category)
    {
        var entity = await repository.GetByIdAsync<Category, int>(category.Id);
        if (entity is null)
            return false;

        if (entity.Name != category.Name)
            entity.Name = category.Name;
        if (entity.Description != category.Description)
            entity.Description = category.Description;
        await repository.UpdateAsync(entity);
        await repository.SaveChangesAsync();
        return true;
    }

    public async Task<Domain.Categories.Category> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync<Category, int>(id);
        var category = entity?.GetDomainCategory() ?? Domain.Categories.Category.GetNull();
        return category;
    }

    public async Task<IEnumerable<Domain.Categories.Category>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync<Category>();
        var categories = entities.Select(e => e.GetDomainCategory());
        return categories;
    }

    public async Task<Domain.Categories.Category> GetByTitleAsync(string title)
    {
        var entity =
            (await repository.GetByAsync<Category>(c => c.Name == title)).FirstOrDefault();
        if (entity is null)
            return Domain.Categories.Category.GetNull();

        var category = entity.GetDomainCategory();
        return category;
    }

    public async Task<IEnumerable<Domain.Categories.Category>> GetFilteredAsync(Func<Domain.Categories.Category, bool> filter)
    {
        var entities = await repository.GetByAsync<Category>(c => filter(c.GetDomainCategory()));
        var categories = entities.Select(e => e.GetDomainCategory());
        return categories;
    }

    public async Task<bool> AddTodo(int categoryId, int todoId)
    {
        var entity = await repository.GetByIdAsync<Category, int>(categoryId);
        if (entity is null)
            return false;
        var todo = await repository.GetByIdAsync<Todo, int>(todoId);
        if (todo is null)
            return false;
        entity.Todos.Add(await repository.GetByIdAsync<Todo, int>(todoId));
        await repository.UpdateAsync(entity);
        await repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(string title)
    {
        return (await repository.GetByAsync<Category>(c => c.Name == title)).Any();
    }
}
