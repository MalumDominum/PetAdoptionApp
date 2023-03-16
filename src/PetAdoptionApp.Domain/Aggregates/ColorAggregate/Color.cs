using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.ColorAggregate;

public class Color : EntityBase, IAggregateRoot
{
	public string Name { get; set; } = null!;

	public string HexValue { get; set; } = null!;
}
