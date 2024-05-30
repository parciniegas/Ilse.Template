using Ilse.Core.Results;

namespace Ilse.Start.Domain.Categories.Errors;

public class CategoryErrors
{
    public static Error CategoryAlreadyExists(string title) =>
        Error.Conflict("Category.AlreadyExist",
            "Category already exists.",
            $"A Category with title {title} already exists, is not possible create another Category with same title.");

    public static Error CategoryNotFound(int id) =>
        Error.NotFound("Category.NotFound",
            "Category not found.",
            $"A ToDo with id {id} could not be found.");

    public static Error NothingToUpdate() =>
        Error.BadRequest("Category.NothingToUpdate",
            "Nothing to update.",
            "Nothing to update in the category.");
}
