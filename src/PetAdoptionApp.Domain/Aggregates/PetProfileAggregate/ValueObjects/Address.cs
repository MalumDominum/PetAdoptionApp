using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

public class Address : ValueObject
{
	public Location Location { get; } = null!;

	public string FullAddress { get; } = null!;

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
