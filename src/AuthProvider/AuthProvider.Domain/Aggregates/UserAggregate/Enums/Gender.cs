using Ardalis.SmartEnum;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Enums;

public class Gender : SmartEnum<Gender, string>
{
	public static readonly Gender Male = new (nameof(Male), "m");
	public static readonly Gender Female = new (nameof(Female), "f");
	public static readonly Gender Other = new (nameof(Other), "o");

	private Gender(string name, string value) : base(name, value) { }
}
