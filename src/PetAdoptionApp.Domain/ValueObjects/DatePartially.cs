using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.ValueObjects;

public class DatePartially : ValueObject
{
	RangeOrValue<int> Year { get; set; }

	RangeOrValue<int>? Month { get; set; }

	RangeOrValue<int>? Day { get; set; }

	public DatePartially(RangeOrValue<int> year, RangeOrValue<int>? month = null, RangeOrValue<int>? day = null)
	{
		Year = year;
		Month = month;
		Day = day;
	}

	public static bool operator <=(DatePartially datePartially, DateTime dateTime)
	{
		throw new NotImplementedException();
	}

	public static bool operator >=(DatePartially datePartially, DateTime dateTime)
	{
		throw new NotImplementedException();
	}

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Year;
		yield return Month != null ? Month : int.MinValue;
		yield return Day != null ? Day : int.MinValue;
	}
}
