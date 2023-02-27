using PetAdoptionApp.SharedKernel;

namespace PetAdoptionApp.Domain.Aggregates.ContributorAggregate.Events;

public class ContributorDeletedEvent : DomainEventBase
{
	public int ContributorId { get; set; }

	public ContributorDeletedEvent(int contributorId)
	{
		ContributorId = contributorId;
	}
}
