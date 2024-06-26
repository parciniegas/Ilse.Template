using Ilse.Repository.Contracts;
using Ilse.Start.Domain.Todos;
using Note = Ilse.Start.Infrastructure.Repository.Todo.Note;
using Tag = Ilse.Start.Infrastructure.Repository.Todo.Tag;

namespace Ilse.Start.Infrastructure.Repository.EntityFramework;

public class TodoRepository(IRepository repository): ITodoRepository
{
    public async Task<int> CreateAsync(Domain.Todos.Todo todo)
    {
        var entity = new Todo.Todo(todo.Title, todo.CategoryId, todo.Description)
        {
            Tags = todo.Tags.Select(t => new Tag(t.Name, t.Value)).ToList()
        };
        await repository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Domain.Todos.Todo todo)
    {
        var entity = await repository.GetByIdAsync<Todo.Todo, int>(todo.Id);
        if (entity is null)
            return false;

        entity.Title = todo.Title;
        entity.Description = todo.Description;
        entity.Tags = todo.Tags.Select(t => new Tag(t.Name, t.Value)).ToList();
        await repository.UpdateAsync(entity);
        return true;
    }

    public async Task<bool> CompleteAsync(int id, string notes)
    {
        var entity = await repository.GetByIdAsync<Todo.Todo, int>(id);
        if (entity is null)
            return false;

        entity.CompletedAt = DateTime.Now;
        entity.CompletedNotes = notes;
        await repository.UpdateAsync(entity);
        return true;
    }

    public async Task<bool> AddNoteAsync(int id, string note)
    {
        var toDo = await repository.GetByIdAsync<Todo.Todo, int>(id);
        if (toDo is null)
            return false;
        toDo.Notes.Add(new Note(note, DateTime.Now));
        await repository.UpdateAsync(toDo);
        return true;
    }

    public async Task<Domain.Todos.Todo> GetByIdAsync(int id)
    {
        var todo = await repository.GetByIdAsync<Todo.Todo, int>(id);
        var todoItem = todo?.GetTodo() ?? Domain.Todos.Todo.GetNull();
        return todoItem;
    }

    public async Task<IEnumerable<Domain.Todos.Todo>> GetAllAsync()
    {
        var todos = await repository.GetAllAsync<Todo.Todo>();
        var todoItems = todos.Select(t => t.GetTodo());
        return todoItems;
    }

    public async Task<Domain.Todos.Todo> GetByTitleAsync(string title)
    {
        var todos = await repository.GetByAsync<Todo.Todo>(t => t.Title == title);
        var todo = todos.FirstOrDefault();
        return todo?.GetTodo() ?? Domain.Todos.Todo.GetNull();
    }

    public async Task<IEnumerable<Domain.Todos.Todo>> GetByStatusAsync(bool isDone)
    {
        var todos = await repository.GetByAsync<Todo.Todo>(t => t.IsDone == isDone);
        var todoItems = todos.Select(t => t.GetTodo());
        return todoItems;
    }

    public async Task<bool> ExistsAsync(string title)
    {
        var exist = (await repository.GetByAsync<Todo.Todo>(t => t.Title == title)).Any();
        return exist;
    }

    public async Task SaveChangesAsync()
    {
        await repository.SaveChangesAsync();
    }
}
