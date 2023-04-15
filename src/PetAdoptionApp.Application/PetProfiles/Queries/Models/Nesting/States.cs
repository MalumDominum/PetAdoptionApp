using PetAdoptionApp.Domain.Aggregates.StateAggregate;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;

public class States
{
	private readonly List<State>? _active;
	public IReadOnlyCollection<State>? Active => _active?.AsReadOnly();

	private readonly List<State>? _history;
	public IReadOnlyCollection<State>? History => _history?.AsReadOnly();

	#region Constructors

	public States(List<State>? active, List<State>? history)
	{
		_active = active;
		_history = history;
	}

	public States() { }

	#endregion
}
