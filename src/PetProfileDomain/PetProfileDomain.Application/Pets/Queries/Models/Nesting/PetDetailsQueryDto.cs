using PetProfileDomain.Application.Species.Models;

namespace PetProfileDomain.Application.Pets.Queries.Models.Nesting;

public record PetDetailsQueryDto(
	BreedDto? Breed,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
