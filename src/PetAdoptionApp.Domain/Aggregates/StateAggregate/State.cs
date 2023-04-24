using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.StateAggregate;

public class State : EntityBase<Guid>, IAggregateRoot, IEquatable<State>
{
	public Status Status { get; init; } = null!;

	public DateTime AssignedTime { get; init; }

	public DateTime? ResolvedDate { get; init; }

	public Guid PetProfileId { get; init; }

	#region Constructors

	public State(int statusValue, DateTime assignedTime)
	{
		Status = Status.FromValue(statusValue);
		AssignedTime = assignedTime;
	}

	public State() { }

	#endregion

	public override bool Equals(object? obj) => obj is State state && Equals(state);

	public bool Equals(State? other) => other != null && Status == other.Status;

	public override int GetHashCode() => Status.Value.GetHashCode();
}
