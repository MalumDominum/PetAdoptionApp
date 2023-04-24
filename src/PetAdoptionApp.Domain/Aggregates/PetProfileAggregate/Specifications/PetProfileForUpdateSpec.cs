using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileForUpdateSpec : Specification<PetProfile>
{
	public PetProfileForUpdateSpec(Guid id)
	{
		Query.Include(p => p.PetColors);
		Query.Include(p => p.States);

		Query.Where(p => p.Id == id)
			 .AsNoTracking();
	}
}
