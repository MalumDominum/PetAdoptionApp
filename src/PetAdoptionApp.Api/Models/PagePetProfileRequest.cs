namespace PetAdoptionApp.Api.Models;

public record PagePetProfileRequest(
	DateTime? FromTime,
	//Guid? UserId,
	string? NameLike,
	string? Gender,
	DateOnly? BirthDateFrom,
	DateOnly? BirthDateTo,
	List<int>? SizeIds,
	List<int>? ColorIds,
	int? SpeciesId,
	List<int>? BreedIds,

	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
