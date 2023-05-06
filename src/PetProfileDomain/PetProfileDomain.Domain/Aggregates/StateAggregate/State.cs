using PetAdoptionApp.SharedKernel.DddModelsDefinition;
using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Domain.Aggregates.StateAggregate;

public class State : EntityBase<Guid>, IAggregateRoot, IEquatable<State>
{
	public Status Status { get; init; } = null!;

	public DateTime AssignedTime { get; init; }

	public DateTime? ResolvedDate { get; init; }

	public Guid PetId { get; init; }

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
