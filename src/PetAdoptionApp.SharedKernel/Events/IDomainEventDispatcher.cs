namespace PetAdoptionApp.SharedKernel.Events;

public interface IDomainEventDispatcher
{
	Task DispatchAndClearEvents(IEnumerable<DomainEventSender> entitiesWithEvents);
}
