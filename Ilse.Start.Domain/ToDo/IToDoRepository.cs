namespace Ilse.Start.Domain.ToDo;

public interface IToDoRepository
{
    public int Create(ToDoItem todo);
    public void Update(ToDoItem todo);
    public ToDoItem GetById(int id);
    public IEnumerable<ToDoItem> GetAll();
    public IEnumerable<ToDoItem> GetByTitle(string title);
    public IEnumerable<ToDoItem> GetByStatus(bool isDone);
}