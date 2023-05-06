namespace PetProfileDomain.Api.Models;

public record PagePetRequest(
	int? Page,

	//Guid? UserId,
	string? NameLike,
	string? Gender,
	int? SpeciesId,
	List<int>? BreedIds,
	List<int>? StateIds,
	List<int>? SizeIds,
	List<int>? ColorIds,
	DateTime? StatusChangedAfter,

	DateOnly? BirthDateFrom,
	DateOnly? BirthDateTo,

	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar);
