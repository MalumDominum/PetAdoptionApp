using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications;

public record PetProfileFilteringValues(
	string? NameLike,
	int? SpeciesId,
	int? BreedId,
	string? NearLocation,
	List<int>? StateIds,
	Gender? Gender,
	int? HeightFrom,
	int? HeightTo,
	List<int>? ColorIds,

	DateOnly? BirthDateFrom,
	DateOnly? BirthDateTo,

	bool? Neutering,
	bool? Healthy,
	bool? Vaccination,
	bool? HasCollar
);
