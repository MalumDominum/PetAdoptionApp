using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.BreedAggregate;

public class Breed : EntityBase, IAggregateRoot
{
	public string Name { get; set; } = null!;
}
