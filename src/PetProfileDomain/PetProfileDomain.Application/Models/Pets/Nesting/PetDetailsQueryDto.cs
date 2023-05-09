using PetProfileDomain.Application.Models.Species;

namespace PetProfileDomain.Application.Models.Pets.Nesting;

public record PetDetailsQueryDto(
	BreedDto? Breed,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
