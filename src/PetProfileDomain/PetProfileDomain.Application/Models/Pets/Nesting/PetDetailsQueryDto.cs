namespace PetProfileDomain.Application.Models.Models.Nesting;

public record PetDetailsQueryDto(
	BreedDto? Breed,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
