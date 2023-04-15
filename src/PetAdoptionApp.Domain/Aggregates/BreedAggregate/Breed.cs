using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.BreedAggregate;

public class Breed : EntityBase<int>, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public int SpeciesId { get; set; }
}
