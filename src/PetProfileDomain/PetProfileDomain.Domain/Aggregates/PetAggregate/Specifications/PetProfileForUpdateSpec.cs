using Ardalis.Specification;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetForUpdateSpec : Specification<Pet>
{
	public PetForUpdateSpec(Guid id)
	{
		Query.Include(p => p.PetColors);
		Query.Include(p => p.States);

		Query.Where(p => p.Id == id)
			 .AsNoTracking();
	}
}
