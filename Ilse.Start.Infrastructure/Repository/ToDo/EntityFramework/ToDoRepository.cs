using Ilse.Repository.Contracts;
using Ilse.Start.Domain.ToDo;

namespace Ilse.Start.Infrastructure.Repository.ToDo.EntityFramework;

public class ToDoRepository(IRepository repository): IToDoRepository
{
    public async Task<int> CreateAsync(ToDoItem todoItem)
    {
        var toDo = new ToDo(todoItem.Title, todoItem.Description)
        {
            Tags = todoItem.Tags.Select(t => new Tag(t.Name, t.Value)).ToList()
        };
        await repository.AddAsync(toDo);
        return toDo.Id;
    }

    public async Task<bool> UpdateAsync(ToDoItem todoItem)
    {
        var toDo = await repository.GetByIdAsync<ToDo, int>(todoItem.Id);
        if (toDo is null)
            return false;

        toDo.Title = todoItem.Title;
        toDo.Description = todoItem.Description;
        toDo.Tags = todoItem.Tags.Select(t => new Tag(t.Name, t.Value)).ToList();
        await repository.UpdateAsync(toDo);
        return true;
    }

    public async Task<bool> CompleteAsync(int id, string notes)
    {
        var toDo = await repository.GetByIdAsync<ToDo, int>(id);
        if (toDo is null)
            return false;

        toDo.CompletedAt = DateTime.Now;
        toDo.CompletedNotes = notes;
        await repository.UpdateAsync(toDo);
        return true;
    }

    public async Task<bool> AddNoteAsync(int id, string note)
    {
        var toDo = await repository.GetByIdAsync<ToDo, int>(id);
        if (toDo is null)
            return false;
        toDo.Notes.Add(new Note(note, DateTime.Now));
        await repository.UpdateAsync(toDo);
        return true;
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
