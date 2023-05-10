namespace PetProfileDomain.Application.Models.Pets;

public record PetDetailsCommandDto(
	int? BreedId,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
