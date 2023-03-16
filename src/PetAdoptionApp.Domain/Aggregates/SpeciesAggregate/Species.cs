using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;

public class Species : EntityBase, IAggregateRoot
{
	public string Title { get; set; } = null!;
}
