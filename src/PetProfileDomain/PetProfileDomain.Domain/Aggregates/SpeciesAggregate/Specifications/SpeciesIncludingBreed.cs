using Ardalis.Specification;

namespace PetProfileDomain.Domain.Aggregates.SpeciesAggregate.Specifications;

public sealed class SpeciesIncludingBreed : Specification<Species>
{
	public SpeciesIncludingBreed() => Query.Include(p => p.Breeds);
}
