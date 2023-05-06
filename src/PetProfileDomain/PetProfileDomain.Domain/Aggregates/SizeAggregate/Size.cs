using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetProfileDomain.Domain.Aggregates.SizeAggregate;

public class Size : EntityBase<int>, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public int From { get; set; }

	public int To { get; set; }
}
