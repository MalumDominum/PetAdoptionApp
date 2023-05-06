using PetAdoptionApp.SharedKernel.DddModelsDefinition;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Domain.Aggregates.SpeciesAggregate;

public class Species : EntityBase<int>, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public List<Breed>? Breeds { get; set; }
}
