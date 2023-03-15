using MediatR;

namespace PetAdoptionApp.SharedKernel.Events;

public abstract class DomainEventBase : INotification
{
	public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
