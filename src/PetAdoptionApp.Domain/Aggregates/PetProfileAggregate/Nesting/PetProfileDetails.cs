using PetAdoptionApp.Domain.Aggregates.BreedAggregate;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Nesting;

public class PetProfileDetails
{
	public int? BreedId { get; set; }
	public Breed? Breed { get; set; }

	public bool? Neutering { get; set; }

	public bool? Healthy { get; set; }

	public bool? Vaccination { get; set; }

	public bool? HasPassport { get; set; }

	public bool? HasCollar { get; set; }
}
