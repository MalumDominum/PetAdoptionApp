using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Entities;

public class TransferFact : EntityBase<Guid>
{
	public Guid OldOwnerId { get; set; }

	public Guid NewOwnerId { get; set; }

	public DateTime TransferDateTime { get; set; }
}
