namespace Ilse.Start.Domain.Todos;

public interface ITodoRepository
{
    public Task<int> CreateAsync(Todo todo);
    public Task<bool> UpdateAsync(Todo todo);
    public Task<bool> CompleteAsync(int id, string notes);
    public Task<bool> AddNoteAsync(int id, string note);
    public Task<Todo> GetByIdAsync(int id);
    public Task<IEnumerable<Todo>> GetAllAsync();
    public Task<Todo> GetByTitleAsync(string title);
    public Task<IEnumerable<Todo>> GetByStatusAsync(bool isDone);
    public Task<bool> ExistsAsync(string title);
}
