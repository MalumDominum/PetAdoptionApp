using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Common;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileByIdSpec : Specification<PetProfile>
{
	public PetProfileByIdSpec(Guid id)
	{
		Query.DetailedPetProfileIncludeWithOrdering();

		Query.Where(p => p.Id == id);
	}
}
