using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.ProjectAggregate.Specifications;
public class IncompleteItemsSpec : Specification<ToDoItem>
{
	public IncompleteItemsSpec()
	{
		Query.Where(item => !item.IsDone);
	}
}
