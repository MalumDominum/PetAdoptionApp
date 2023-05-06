using Ardalis.Specification;

namespace PetProfileDomain.Domain.Aggregates.BreedAggregate.Specifications;

public sealed class BreedsBySpeciesIdSpec : Specification<Breed>
{
	public BreedsBySpeciesIdSpec(int speciesId) => Query.Where(b => b.SpeciesId == speciesId);
}
