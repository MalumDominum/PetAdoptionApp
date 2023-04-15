using Ardalis.SmartEnum;

namespace PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;

public class Status : SmartEnum<Status, int>
{
	public static readonly Status NeedsHome = new ("Needs home", 1);
	public static readonly Status NeedsDonation = new("Needs donation", 2);
	public static readonly Status NeedsSitter = new("Needs sitter", 3);
	public static readonly Status Missing = new("Missing", 4);
	public static readonly Status Found = new("Found", 5);

	private Status(string name, int value) : base(name, value) { }
}
