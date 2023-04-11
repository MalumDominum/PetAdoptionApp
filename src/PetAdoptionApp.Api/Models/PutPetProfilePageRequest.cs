namespace PetAdoptionApp.Api.Models;

public record PutPetProfilePageRequest(
	Guid Id,
	string Name,
	string Gender,
	string Description,
	List<int>? ColorIds);
