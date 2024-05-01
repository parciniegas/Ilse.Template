using Ilse.Start.Domain.ToDo;
using Microsoft.EntityFrameworkCore;

namespace Ilse.Start.Infrastructure.Repository.ToDo.InMemory;

public class ToDoRepository: IToDoRepository
{
    private readonly List<ToDo> _todos = [];

    public Task<int> CreateAsync(ToDoItem todoItem)
    {
        var id = _todos.Count + 1;
        var toDo = new ToDo(id, todoItem.Title, todoItem.Description, todoItem.CreatedAt, todoItem.CompletedAt,
            todoItem.CompletedNotes);
        _todos.Add(toDo);
        return Task.FromResult(id);
    }

    public async Task UpdateAsync(ToDoItem todoItem)
    {
        var todoToUpdate = (await _todos.AsQueryable().FirstOrDefaultAsync(t => t.Id == todoItem.Id))
            ?? throw new Exception($"ToDo with id {todoItem.Id} not found");
        todoToUpdate.CompletedAt = todoItem.CompletedAt;
        todoToUpdate.Notes = todoItem.CompletedNotes;
    }

    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        var todos = _todos.Select(t => new ToDoItem(t.Title, t.Description, t.CompletedAt, t.Notes)
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt
        });
        return await Task.FromResult(todos);
    }

    public async Task<ToDoItem> GetByIdAsync(int id)
    {
        var todo = await _todos.AsQueryable().FirstOrDefaultAsync(t => t.Id == id);
        if (todo == null)
            return ToDoItem.GetNull();

        var item = new ToDoItem(todo.Title, todo.Description, todo.CompletedAt, todo.Notes)
        {
            Id = todo.Id,
            CreatedAt = todo.CreatedAt
        };
        return item;
    }

    public async Task<ToDoItem> GetByTitleAsync(string title)
    {
        var todo = await _todos.AsQueryable().FirstOrDefaultAsync(t => t.Title == title);
        if (todo == null)
            return ToDoItem.GetNull();

        var item = new ToDoItem(todo.Title, todo.Description, todo.CompletedAt, todo.Notes)
        {
            Id = todo.Id,
            CreatedAt = todo.CreatedAt
        };
        return item;
    }

    public async Task<IEnumerable<ToDoItem>> GetByStatusAsync(bool isDone)
    {
        var todos = _todos.Where(t => t.IsDone == isDone)
            .Select(t => new ToDoItem(t.Title, t.Description, t.CompletedAt, t.Notes)
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt
        });

        return await Task.FromResult(todos);
    }

    public async Task<IEnumerable<ToDoItem>> GetToDoItemsAsync(Func<ToDoItem, bool> predicate)
    {
        var todos = _todos.Where(t => predicate(new ToDoItem(t.Title, t.Description, t.CompletedAt, t.Notes)
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt
        })).Select(t => new ToDoItem(t.Title, t.Description, t.CompletedAt, t.Notes)
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt
        });

        return await Task.FromResult(todos);
    }

    public Task<bool> ExistsAsync(string title)
    {
        var exists = _todos.Any(t => t.Title == title);
        return Task.FromResult(exists);
    }
}
