using PetAdoptionApp.Core.ProjectAggregate;

namespace PetAdoptionApp.UnitTests;

public class ToDoItemBuilder
{
    private ToDoItem _todo = new();

    public ToDoItemBuilder Id(int id)
    {
        _todo.Id = id;
        return this;
    }

    public ToDoItemBuilder Title(string title)
    {
        _todo.Title = title;
        return this;
    }

    public ToDoItemBuilder Description(string description)
    {
        _todo.Description = description;
        return this;
    }

    public ToDoItemBuilder WithDefaultValues()
    {
        _todo = new ToDoItem { Id = 1, Title = "Test Item", Description = "Test Description" };

        return this;
    }

    public ToDoItem Build() => _todo;
}
