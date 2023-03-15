using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.ValueObjects;

public class RangeOrValue<T> : ValueObject
	where T : IComparable
{
	public T? Value { get; set; }

	public T? From { get; set; }

	public T? To { get; set; }


	public T ToOrValue => To != null ? To : Value!;

	public T FromOrValue => From != null ? From : Value!;

	#region Comparing Operators

	public static bool operator <(RangeOrValue<T> left, T right) =>
		left.ToOrValue.CompareTo(right) < 0;

	public static bool operator <=(RangeOrValue<T> left, T right) =>
		left.ToOrValue.CompareTo(right) <= 0;

	public static bool operator >(RangeOrValue<T> left, T right) =>
		left.FromOrValue.CompareTo(right) > 0;

	public static bool operator >=(RangeOrValue<T> left, T right) =>
		left.FromOrValue.CompareTo(right) >= 0;

	#endregion

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value != null ? Value : int.MinValue;
		yield return From != null ? From : int.MinValue;
		yield return To != null ? To : int.MinValue;
	}
}
