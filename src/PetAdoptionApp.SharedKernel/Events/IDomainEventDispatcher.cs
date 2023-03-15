using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.SharedKernel.Events;

public interface IDomainEventDispatcher
{
	Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
}