using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public sealed class PetProfileSavedSpec : Specification<PetProfile>
{
	public PetProfileSavedSpec(int ownerId) { }
}
