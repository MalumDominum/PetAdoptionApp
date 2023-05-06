using Ardalis.SmartEnum;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;

public class Gender : SmartEnum<Gender, string>
{
	public static readonly Gender Male = new (nameof(Male), "m");
	public static readonly Gender Female = new (nameof(Female), "f");
	public static readonly Gender Unknown = new (nameof(Unknown), "u");

	private Gender(string name, string value) : base(name, value) { }
}
