using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using Xunit;

namespace PetProfileDomain.UnitTests.ValueObjects;

public class Tests
{
	[Theory]
	[InlineData(1, 1, 1, true)]
	[InlineData(1, 0, 1, false)]

	[InlineData(2023, null, null, true)]
	[InlineData(2023, null, 15, false)]

	[InlineData(2023, 8, null, true)]
	[InlineData(2023, 13, null, false)]
	
	[InlineData(2023, 8, 31, true)]
	[InlineData(2023, 8, 32, false)]

	[InlineData(2023, 2, 28, true)]
	[InlineData(2023, 2, 29, false)]
	[InlineData(2024, 2, 29, true)]
	public void IsValidMethodTest(int year, int? month, int? day, bool expectedResult)
	{
		Assert.Equal(new PartialPossibleDate(year, month, day).IsValid(), expectedResult);
	}


	[Theory]
	[InlineData(1, 0, false)]
	[InlineData(0, 1, false)]

	[InlineData(0, 0, true)]
	[InlineData(-1, 0, true)]
	[InlineData(0, -1, true)]
	// Day check is not as critical, so the implementation was missed
	public void IsPastMethodTest(int yearDiff, int? monthDiff, bool expectedResult)
	{
		Assert.Equal(new PartialPossibleDate(
				DateTime.Now.Year + yearDiff,
				DateTime.Now.Month + monthDiff,
				1)
			.IsPast(), expectedResult);
	}
}
