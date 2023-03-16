using PetAdoptionApp.SharedKernel.Events;

namespace PetAdoptionApp.SharedKernel.DddModelsDefinition;

public abstract class EntityBase<TId> : DomainEventSender
{
	public TId Id { get; set; } = default!;
}
