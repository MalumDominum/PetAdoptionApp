using Ardalis.Specification;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetColorByPetIdSpec : Specification<PetColor>
{
	public PetColorByPetIdSpec(Guid PetId)
	{
		Query.Where(pc => pc.PetId == PetId);
	}
}
