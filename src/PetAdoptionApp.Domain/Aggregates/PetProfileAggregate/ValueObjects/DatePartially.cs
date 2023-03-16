using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

public class DatePartially : ValueObject
{
	public RangeOrValue<int> Year { get; } = null!;

	public RangeOrValue<int>? Month { get; }

	public RangeOrValue<int>? Day { get; }

	#region Constructors

	public DatePartially(RangeOrValue<int> year, RangeOrValue<int>? month = null, RangeOrValue<int>? day = null)
	{
		Year = year;
		Month = month;
		Day = day;
	}

	public DatePartially() { }

	#endregion

	//public static bool TryCreate(int year, int month, int day, out DatePartially datePartially)
	//{
	//	var wasValidated = DateOnly.TryParse($"{year}/{month}/{day}", out _);
	//	if (wasValidated) datePartially = new DatePartially(year, month, day);
	//	return ;
	//}

	#region Comparing Operators

	public static bool operator <=(DatePartially datePartially, DateOnly date)
	{
		throw new NotImplementedException();
	}

	public static bool operator >=(DatePartially datePartially, DateOnly date)
	{
		throw new NotImplementedException();
	}

	#endregion

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Year;
		yield return Month != null ? Month : int.MinValue;
		yield return Day != null ? Day : int.MinValue;
	}
}
