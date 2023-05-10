using PetAdoptionApp.SharedKernel.DomainEvents;

namespace PetAdoptionApp.SharedKernel.DddModelsDefinition;

public abstract class EntityBase<TId> : DomainEventSender
{
	public TId Id { get; set; } = default!;
}
