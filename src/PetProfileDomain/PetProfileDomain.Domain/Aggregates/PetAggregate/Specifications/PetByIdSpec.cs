using Ardalis.Specification;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Extensions;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetByIdSpec : Specification<Pet>
{
	public PetByIdSpec(Guid id)
	{
		Query.DetailedPetIncludeWithOrdering();

		Query.Where(p => p.Id == id);
	}
}
