using Ardalis.Specification;

namespace PetAdoptionApp.Domain.Aggregates.SpeciesAggregate.Specifications;

public sealed class SpeciesIncludingBreed : Specification<Species>
{
	public SpeciesIncludingBreed() => Query.Include(p => p.Breeds);
}
