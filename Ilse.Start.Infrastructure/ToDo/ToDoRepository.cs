using Ilse.Start.Domain.ToDo;

namespace Ilse.Start.Infrastructure.ToDo;

public class ToDoRepository: IToDoRepository
{
    public int Create(Domain.ToDo.ToDoItem todo)
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.ToDo.ToDoItem todo)
    {
        throw new NotImplementedException();
    }

    public Domain.ToDo.ToDoItem GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Domain.ToDo.ToDoItem> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Domain.ToDo.ToDoItem> GetByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Domain.ToDo.ToDoItem> GetByStatus(bool isDone)
    {
        throw new NotImplementedException();
    }
}