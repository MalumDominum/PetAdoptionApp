using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

public record PetProfileFilteringValues(
	string? NameLike,
	Gender? Gender,
	int? SpeciesId,
	List<int>? BreedIds,
	string? NearLocation,
	List<int>? StateIds,
	List<int>? SizeIds,
	List<int>? ColorIds,

	DateOnly? BirthDateFrom,
	DateOnly? BirthDateTo,

	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasPassport,
	bool? HasCollar
);
