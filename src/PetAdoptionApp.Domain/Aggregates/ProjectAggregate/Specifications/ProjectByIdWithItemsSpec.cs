using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.ProjectAggregate.Specifications;
public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
	public ProjectByIdWithItemsSpec(int projectId)
	{
		Query
				.Where(project => project.Id == projectId)
				.Include(project => project.Items);
	}
}
