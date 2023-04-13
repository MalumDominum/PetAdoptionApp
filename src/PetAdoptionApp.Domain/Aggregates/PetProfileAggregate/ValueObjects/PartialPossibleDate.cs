using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

public class PartialPossibleDate : ValueObject
{
	public int Year { get; init; }

	public int? Month { get; init; }

	public int? Day { get; init; }

	public bool IsExact { get; init; }

	#region Constructors

	public PartialPossibleDate(int year, int? month = null, int? day = null, bool isExact = false)
	{
		Year = year;
		Month = month;
		Day = day;
		IsExact = isExact;
	}

	public PartialPossibleDate() { }

	#endregion

	public bool IsValid() => Year > 0 && ((Month == null && Day == null) || (Month is <= 12 && Day == null) 
	                                     || DateOnly.TryParse($"{Year}/{Month}/{Day}", out _));

	public bool IsPast() => Year < DateTime.Today.Year
	                        || (Year == DateTime.Today.Year
	                            && (Month == null || Month <= DateTime.Today.Month));

	#region Comparing Operators

	public static bool operator <=(PartialPossibleDate left, DateOnly right) =>
		left.Year == right.Year
			? new DateOnly(left.Year, left.Month ?? 1, left.Day ?? 1) <= right
			: left.Year < right.Year;

	public static bool operator >=(PartialPossibleDate left, DateOnly right) =>
		left.Year == right.Year
			? new DateOnly(left.Year, left.Month ?? 12, left.Day ?? 27) >= right
			: left.Year > right.Year;

	#endregion

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Year;
		yield return Month ?? int.MinValue;
		yield return Day ?? int.MinValue;
	}
}
