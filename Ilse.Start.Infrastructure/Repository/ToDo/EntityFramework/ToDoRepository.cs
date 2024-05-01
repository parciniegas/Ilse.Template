using Ilse.Repository.Contracts;
using Ilse.Start.Domain.ToDo;

namespace Ilse.Start.Infrastructure.Repository.ToDo.EntityFramework;

public class ToDoRepository(IRepository repository): IToDoRepository
{
    public async Task<int> CreateAsync(ToDoItem todoItem)
    {
        var toDo = new ToDo(todoItem.Title, todoItem.Description);
        await repository.AddAsync(toDo);
        return toDo.Id;
    }

    public async Task UpdateAsync(ToDoItem todoItem)
    {
        var toDo =
            new ToDo(todoItem.Id, todoItem.Title, todoItem.Description, todoItem.CreatedAt, todoItem.CompletedAt, todoItem.CompletedNotes);
        await repository.UpdateAsync(toDo);
    }

    public async Task<ToDoItem> GetByIdAsync(int id)
    {
        var todo = await repository.GetByIdAsync<ToDo, int>(id);
        var todoItem = todo?.GetToDoItem() ?? ToDoItem.GetNull();
        return todoItem;
    }

    public Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ToDoItem>> GetByStatusAsync(bool isDone)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ToDoItem>> GetToDoItemsAsync(Func<ToDoItem, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(string title)
    {
        throw new NotImplementedException();
    }
}
