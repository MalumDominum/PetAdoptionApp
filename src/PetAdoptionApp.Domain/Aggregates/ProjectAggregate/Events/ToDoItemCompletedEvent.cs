using PetAdoptionApp.SharedKernel;

namespace PetAdoptionApp.Domain.Aggregates.ProjectAggregate.Events;

public class ToDoItemCompletedEvent : DomainEventBase
{
	public ToDoItem CompletedItem { get; set; }

	public ToDoItemCompletedEvent(ToDoItem completedItem)
	{
		CompletedItem = completedItem;
	}
}
