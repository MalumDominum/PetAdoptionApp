using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using Xunit;

namespace PetAdoptionApp.UnitTests.ValueObjects;

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


	[Theory]
	[InlineData(2023, 10, 2, 2023, 10, 2, true)]
	[InlineData(2023, 10, 2, 2023, 10, 3, true)]
	[InlineData(2023, 10, 2, 2023, 10, 1, false)]

	[InlineData(2023, 10, null, 2023, 10, 1, true)]
	[InlineData(2023, null, null, 2023, 10, 1, true)]
	public void BiggerOrEqualOperatorTest(int leftYear, int? leftMonth, int? leftDay,
										  int rightYear, int rightMonth, int rightDay, bool expectedResult)
	{
		Assert.Equal(
			new PartialPossibleDate(leftYear, leftMonth, leftDay)
				<= new DateOnly(rightYear, rightMonth, rightDay),
			expectedResult);
	}


	[Theory]
	[InlineData(2023, 10, 2, 2023, 10, 2, true)]
	[InlineData(2023, 10, 2, 2023, 10, 3, false)]
	[InlineData(2023, 10, 2, 2023, 10, 1, true)]

	[InlineData(2023, 10, null, 2023, 10, 1, true)]
	[InlineData(2023, null, null, 2023, 10, 1, true)]
	public void LesserOrEqualOperatorTest(int leftYear, int? leftMonth, int? leftDay,
		int rightYear, int rightMonth, int rightDay, bool expectedResult)
	{
		Assert.Equal(
			new PartialPossibleDate(leftYear, leftMonth, leftDay)
			>= new DateOnly(rightYear, rightMonth, rightDay),
			expectedResult);
	}
}
