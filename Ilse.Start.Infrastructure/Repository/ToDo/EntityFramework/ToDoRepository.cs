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

    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        var todos = await repository.GetAllAsync<ToDo>();
        var todoItems = todos.Select(t => t.GetToDoItem());
        return todoItems;
    }

    public async Task<ToDoItem> GetByTitleAsync(string title)
    {
        var todos = await repository.GetByAsync<ToDo>(t => t.Title == title);
        var todo = todos.FirstOrDefault();
        return todo?.GetToDoItem() ?? ToDoItem.GetNull();
    }

    public async Task<IEnumerable<ToDoItem>> GetByStatusAsync(bool isDone)
    {
        var todos = await repository.GetByAsync<ToDo>(t => t.IsDone == isDone);
        var todoItems = todos.Select(t => t.GetToDoItem());
        return todoItems;
    }

    public async Task<bool> ExistsAsync(string title)
    {
        var exist = (await repository.GetByAsync<ToDo>(t => t.Title == title)).Any();
        return exist;
    }
}
