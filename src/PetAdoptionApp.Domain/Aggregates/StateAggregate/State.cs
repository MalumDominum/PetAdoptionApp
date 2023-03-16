using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.StateAggregate;

public class State : EntityBase, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public DateTime AssignedTime { get; set; }

	public DateTime? ResolvedDate { get; set; }
}
