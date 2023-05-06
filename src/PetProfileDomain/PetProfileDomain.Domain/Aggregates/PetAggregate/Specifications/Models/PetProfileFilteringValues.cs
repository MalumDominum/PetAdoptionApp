using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Specifications.Models;

public record PetFilteringValues(
	string? NameLike,
	Gender? Gender,
	int? SpeciesId,
	List<int>? BreedIds,
	string? NearLocation,
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
	bool? HasCollar
);
