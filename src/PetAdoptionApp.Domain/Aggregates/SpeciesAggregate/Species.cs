using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;

public class Species : EntityBase<int>, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public List<Breed>? Breeds { get; set; }
}
