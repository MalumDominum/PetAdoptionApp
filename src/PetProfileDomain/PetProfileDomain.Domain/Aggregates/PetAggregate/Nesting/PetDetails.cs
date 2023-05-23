using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Nesting;

public class PetDetails
{
	public int? BreedId { get; set; }
	public Breed? Breed { get; set; }

	public bool? Neutering { get; set; }

	public bool? Healthy { get; set; }

	public bool? Vaccination { get; set; }

	public bool? LitterBoxTrained { get; set; }

	public bool? HasPassport { get; set; }

	public bool? HasCollar { get; set; }
}
