using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetProfileDomain.Domain.Aggregates.ColorAggregate;

public class Color : EntityBase<int>, IAggregateRoot
{
	public string Name { get; set; } = null!;

	public string HexValue { get; set; } = null!;
}
