using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.StateAggregate;

public class State : EntityBase<Guid>, IAggregateRoot
{
	public Status Status { get; set; } = null!;

	public DateTime AssignedTime { get; set; }

	public DateTime? ResolvedDate { get; set; }

	public Guid PetProfileId { get; set; }

	#region Constructors

	public State(int statusValue, DateTime assignedTime)
	{
		Status = Status.FromValue(statusValue);
		AssignedTime = assignedTime;
	}

	public State() { }

	#endregion
}
