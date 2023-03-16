using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetAdoptionApp.SharedKernel.Events;

public class DomainEventSender
{
	private readonly List<DomainEventBase> _domainEvents = new();

	[NotMapped]
	[JsonIgnore]
	public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

	protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
	internal void ClearDomainEvents() => _domainEvents.Clear();
}
