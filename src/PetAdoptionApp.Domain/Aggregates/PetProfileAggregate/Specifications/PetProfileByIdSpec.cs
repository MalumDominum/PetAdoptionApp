using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileByIdSpec : Specification<PetProfile>
{
	public PetProfileByIdSpec(Guid id)
	{
		Query.Include(p => p.Colors);

		Query.Where(p => p.Id == id);
	}
}
