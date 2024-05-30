using Ilse.Core.Results;

namespace Ilse.Start.Domain.Todos.Errors;

public class ToDoErrors
{
    public static Error ToDoNotFound(int id) =>
        Error.NotFound("ToDo.NotFound",
                     $"ToDo with Id {id} not found.",
                       $"A ToDo with Id {id} could not be found.");

    public static Error ToDoNotFound(string title) =>
        Error.NotFound("ToDo.NotFound",
            $"ToDo with Title {title} not found.",
            $"A ToDo with Title {title} could not be found.");

    public static Error ToDoAlreadyExists(string title) =>
        Error.Conflict("ToDo.AlreadyExist",
                    $"ToDo with title {title} already exists.",
                      $"A ToDo with title {title} already exists, is not possible create another ToDo with same title.");
}
