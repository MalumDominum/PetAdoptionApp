using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

public class Address : ValueObject
{
	public Location Location { get; init; } = null!;

	public string FullAddress { get; init; } = null!;

	#region Constructors

	public Address(Location location, string fullAddress)
	{
		Location = location;
		FullAddress = fullAddress;
	}

	public Address() { }

	#endregion

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Location;
		yield return FullAddress;
	}
}
