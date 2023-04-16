namespace PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;

public class SeparatedStates
{
	private readonly List<ActiveStateDto>? _active;
	public IReadOnlyCollection<ActiveStateDto>? Active => _active?.AsReadOnly();

	private readonly List<HistoryStateDto>? _history;
	public IReadOnlyCollection<HistoryStateDto>? History => _history?.AsReadOnly();

	#region Constructors

	public SeparatedStates(List<ActiveStateDto>? active, List<HistoryStateDto>? history)
	{
		_active = active;
		_history = history;
	}

	public SeparatedStates() { }

	#endregion
}
