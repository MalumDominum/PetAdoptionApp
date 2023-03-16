using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.HeightAggregate;

public class Height : EntityBase<int>, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public int From { get; set; }

	public int To { get; set; }
}
