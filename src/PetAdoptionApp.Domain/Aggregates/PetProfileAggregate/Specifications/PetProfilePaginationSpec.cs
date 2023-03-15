using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfilePaginationSpec : Specification<PetProfile>
{
	public PetProfilePaginationSpec(DateTime statusChangedDateTime)
	{
		Query.OrderByDescending(p => p.LastUpdateAt);
	}
}
