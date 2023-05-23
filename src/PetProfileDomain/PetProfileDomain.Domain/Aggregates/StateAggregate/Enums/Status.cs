using Ardalis.SmartEnum;

namespace PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

public class Status : SmartEnum<Status, int>
{
	public static readonly Status NeedsHome = new ("Шукає дім", 1);
	public static readonly Status NeedsSitter = new("Потребує перетримки", 2);
	public static readonly Status Sitting = new("На перетримці", 3);
	public static readonly Status Missing = new("Розшукується", 4);
	public static readonly Status Found = new("Загубився", 5);

	public static readonly Status NeedsDonation = new("Потребує допомоги", 6);

	private Status(string name, int value) : base(name, value) { }


	private static readonly IReadOnlyCollection<Status> _conflictedStatuses =
		new List<Status> { NeedsHome, NeedsSitter, Sitting, Missing, Found };

	public static List<Status> FilterConflicted(List<Status> statusList) =>
		statusList.Intersect(_conflictedStatuses).ToList();

	public static List<int> FilterConflicted(List<int> statusList) =>
		statusList.Intersect(_conflictedStatuses.Select(s => s.Value)).ToList();
}
