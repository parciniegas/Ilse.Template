namespace Ilse.Start.Domain.ToDo;

public interface IToDoRepository
{
    public Task<int> CreateAsync(ToDoItem todoItem);
    public Task UpdateAsync(ToDoItem todoItem);
    public Task<ToDoItem> GetByIdAsync(int id);
    public Task<IEnumerable<ToDoItem>> GetAllAsync();
    public Task<ToDoItem> GetByTitleAsync(string title);
    public Task<IEnumerable<ToDoItem>> GetByStatusAsync(bool isDone);
    public Task<bool> ExistsAsync(string title);
}
