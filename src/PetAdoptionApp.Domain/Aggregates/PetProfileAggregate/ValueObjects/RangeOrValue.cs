using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

public class RangeOrValue<T> : ValueObject
	where T : IComparable
{
	public T? Value { get; init; }

	public T? From { get; init; }

	public T? To { get; init; }

	#region Constructors

	public RangeOrValue(T? value, T? from, T? to)
	{
		Value = value;
		From = from;
		To = to;
	}

	public RangeOrValue() { }

	#endregion

	public T ToOrValue => To != null ? To : Value!;

	public T FromOrValue => From != null ? From : Value!;

	public bool Validate() => Value == null && From != null && To != null
							  || Value != null && From == null && To == null;

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
