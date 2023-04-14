using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models;

public record DetailedPetProfileDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	List<Color> Colors);
