using Ardalis.Specification;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications;

public sealed class PetSavedSpec : Specification<Pet>
{
	public PetSavedSpec(int ownerId) { }
}
