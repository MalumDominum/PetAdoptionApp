using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Api.Models;

public record PostPetProfilePageRequest(
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	string Description,
	int SpeciesId,
	List<int>? ColorIds);
