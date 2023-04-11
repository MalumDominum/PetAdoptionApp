namespace PetAdoptionApp.Api.Models;

public record PostPetProfilePageRequest(
	string Name,
	string Gender,
	string Description,
	List<int>? ColorIds);
