using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.StateAggregate.Specifications;

public sealed class ActiveStatesByPetProfileIdSpec : Specification<State>
{
	public ActiveStatesByPetProfileIdSpec(Guid petProfileId)
	{
		Query.Where(s => s.PetProfileId == petProfileId && s.ResolvedDate == null);
	}
}
