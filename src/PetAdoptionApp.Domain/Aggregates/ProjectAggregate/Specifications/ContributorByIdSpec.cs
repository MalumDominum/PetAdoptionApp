using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.ContributorAggregate;

namespace PetAdoptionApp.Domain.Aggregates.ProjectAggregate.Specifications;
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
	public ContributorByIdSpec(int contributorId)
	{
		Query
				.Where(contributor => contributor.Id == contributorId);
	}
}
