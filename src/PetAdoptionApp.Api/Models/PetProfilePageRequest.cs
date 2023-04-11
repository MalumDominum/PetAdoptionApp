namespace PetAdoptionApp.Api.Models;

public record PetProfilePageRequest(
	DateTime? FromTime,
	//Guid? UserId,
	string? NameLike,
	string? Gender);
