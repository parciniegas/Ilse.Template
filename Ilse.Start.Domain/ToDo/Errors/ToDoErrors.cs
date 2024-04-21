using Ilse.Core.Results;

namespace Ilse.Start.Domain.ToDo.Errors;

public class ToDoErrors
{
    public static Error ToDoNotFound(int id) => 
        Error.NotFound("ToDo.NotFound", 
                     $"ToDo with id {id} not found.", 
                       $"A ToDo with id {id} could not be found.");

    public static Error ToDoAlreadyExists(string title) => 
        Error.Conflict("ToDo.AlreadyExist", 
                    $"ToDo with title {title} already exists.",
                      $"A ToDo with title {title} already exists, is not possible create another ToDo with same title.");
}