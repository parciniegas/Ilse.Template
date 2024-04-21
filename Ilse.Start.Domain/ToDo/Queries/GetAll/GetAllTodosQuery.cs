namespace Ilse.Start.Domain.ToDo.Queries.GetAll;

public record GetAllTodosQueryResponse(IEnumerable<ToDoItem> ToDoItems);