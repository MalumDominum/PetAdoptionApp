using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models;

public record PetProfileInListDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	Domain.Aggregates.SpeciesAggregate.Species Species,
	List<Color> Colors);
