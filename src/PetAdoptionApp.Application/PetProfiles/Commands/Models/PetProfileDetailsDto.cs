namespace PetAdoptionApp.Application.PetProfiles.Commands.Models;

public record PetProfileDetailsCommandDto(
	int? BreedId,
	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
