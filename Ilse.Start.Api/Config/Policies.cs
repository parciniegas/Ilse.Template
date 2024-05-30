namespace Ilse.Start.Api.Config;

public static class Policies
{
    public const string AllowAll = "allow.all";
    public const string TodoCreate = "todo.create";
    public const string TodoComplete = "todo.complete";
    public const string TodoDelete = "todo.delete";
    public const string TodoRead = "todo.read";
    public const string TodoUpdate = "todo.update";
    public const string TodoAddNote = "todo.addnote";
    public const string CategoryCreate = "category.create";
    public const string CategoryDelete = "category.delete";
    public const string CategoryRead = "category.read";
    public const string CategoryUpdate = "category.update";
    public const string CategoryAddTodo = "category.addtodo";
    public const string CategoryRemoveTodo = "category.removetodo";
    public const string CategoryAdmin = "category.admin";
}
