﻿using PetAdoptionApp.Core.ProjectAggregate;
using Xunit;

namespace PetAdoptionApp.UnitTests.Core.ProjectAggregate;
public class Project_AddItem
{
    private Project _testProject = new("some name", PriorityStatus.Backlog);

    [Fact]
    public void AddsItemToItems()
    {
        var _testItem = new ToDoItem
        {
            Title = "title",
            Description = "description"
        };

        _testProject.AddItem(_testItem);

        Assert.Contains(_testItem, _testProject.Items);
    }

    [Fact]
    public void ThrowsExceptionGivenNullItem()
    {
#nullable disable
        Action action = () => _testProject.AddItem(null);
#nullable enable

        var ex = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("newItem", ex.ParamName);
    }
}
