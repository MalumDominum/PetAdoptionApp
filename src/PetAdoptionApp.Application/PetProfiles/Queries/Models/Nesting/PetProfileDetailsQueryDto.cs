using PetAdoptionApp.Application.Species.Models;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;

public record PetProfileDetailsQueryDto(
	BreedDto? Breed,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
