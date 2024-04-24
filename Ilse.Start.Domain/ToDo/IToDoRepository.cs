namespace Ilse.Start.Domain.ToDo;

public interface IToDoRepository
{
    public Task<int> CreateAsync(ToDoItem todo);
    public Task UpdateAsync(ToDoItem todo);
    public Task<ToDoItem> GetByIdAsync(int id);
    public Task<IEnumerable<ToDoItem>> GetAllAsync();
    public Task<ToDoItem> GetByTitleAsync(string title);
    public Task<IEnumerable<ToDoItem>> GetByStatusAsync(bool isDone);
    public Task<IEnumerable<ToDoItem>> GetToDoItemsAsync(Func<ToDoItem, bool> predicate);
    Task<bool> ExistsAsync(string title);
}