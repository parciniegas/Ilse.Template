namespace Ilse.Start.Domain.Categories;

public interface ICategoryRepository
{
    Task<int> CreateAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<Category> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetByTitleAsync(string title);
    Task<IEnumerable<Category>> GetFilteredAsync(Func<Category, bool> filter);
    Task<bool> ExistsAsync(string title);
}
