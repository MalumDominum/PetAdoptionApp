using Ardalis.SmartEnum;

namespace PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;

public class Status : SmartEnum<Status, ushort>
{
	public static readonly Status NeedsHome = new ("Needs home", 1);
	public static readonly Status NeedsSitter = new("Needs sitter", 2);
	public static readonly Status Missing = new("Missing", 3);
	public static readonly Status Found = new("Found", 4);

	public static readonly Status NeedsDonation = new("Needs donation", 5);

	private Status(string name, ushort value) : base(name, value) { }


	private static readonly IReadOnlyCollection<Status> _conflictedStatuses =
		new List<Status> { NeedsHome, NeedsSitter, Missing, Found };

	public static List<Status> FilterConflicted(List<Status> statusList) =>
		statusList.Intersect(_conflictedStatuses).ToList();

	public static List<ushort> FilterConflicted(List<ushort> statusList) =>
		statusList.Intersect(_conflictedStatuses.Select(s => s.Value)).ToList();
}
