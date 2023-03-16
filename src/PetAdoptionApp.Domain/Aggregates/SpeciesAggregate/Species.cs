using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;

public class Species : EntityBase<int>, IAggregateRoot
{
	public string Title { get; set; } = null!;
}
