using PetProfileDomain.Application.Pets.Queries.Models.Nesting;
using PetProfileDomain.Application.Species.Models;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;

namespace PetProfileDomain.Application.Pets.Queries.Models;

public record PetInListDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	SpeciesWithoutNestingDto Species,
	Size Size,
	List<Color> Colors,
	List<ActiveStateDto>? ActiveStates);
