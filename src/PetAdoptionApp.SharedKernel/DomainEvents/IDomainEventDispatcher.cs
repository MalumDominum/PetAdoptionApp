namespace PetAdoptionApp.SharedKernel.DomainEvents;

public interface IDomainEventDispatcher
{
	Task DispatchAndClearEvents(IEnumerable<DomainEventSender> entitiesWithEvents);
}
