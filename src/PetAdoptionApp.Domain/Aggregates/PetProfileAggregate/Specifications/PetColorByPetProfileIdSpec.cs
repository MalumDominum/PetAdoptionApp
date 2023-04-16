using Ardalis.Specification;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Linkers;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetColorByPetProfileIdSpec : Specification<PetColor>
{
	public PetColorByPetProfileIdSpec(Guid petProfileId)
	{
		Query.Where(pc => pc.PetProfileId == petProfileId);
	}
}
