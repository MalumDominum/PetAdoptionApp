namespace PetProfileDomain.Application.Pets.Commands.Models;

public record PetDetailsCommandDto(
	int? BreedId,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
