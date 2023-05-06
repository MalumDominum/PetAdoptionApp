using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

public class Location : ValueObject
{
	public double Latitude { get; init; }
	public double Longitude { get; init; }

	#region Constructors

	public Location(double latitude, double longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}

	public Location() { }

	#endregion

	public static bool IsNear(Location location1, Location location2, double distance)
	{
		const double earthRadiusKm = 6371;

		var lat1Rad = ToRadians(location1.Latitude);
		var lat2Rad = ToRadians(location2.Latitude);

		var dLat = lat2Rad - lat1Rad;
		var dLon = ToRadians(location1.Longitude) - ToRadians(location2.Longitude);

		var a = Math.Pow(Math.Sin(dLat / 2), 2) +
				Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
				Math.Pow(Math.Sin(dLon / 2), 2);

		var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
		var distanceKm = earthRadiusKm * c;

		return distanceKm <= distance;
	}

	private static double ToRadians(double degrees) => degrees * Math.PI / 180.0;

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Latitude;
		yield return Longitude;
	}
}
