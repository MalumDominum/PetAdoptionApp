using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models;

public record PetProfileInListDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	Domain.Aggregates.SpeciesAggregate.Species Species,
	Size Size,
	List<Color> Colors);
