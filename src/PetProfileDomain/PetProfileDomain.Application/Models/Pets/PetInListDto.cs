using PetProfileDomain.Application.Models.Pets.Nesting;
using PetProfileDomain.Application.Models.Species;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;

namespace PetProfileDomain.Application.Models.Pets;

public record PetInListDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	SpeciesWithoutNestingDto Species,
	Size Size,
	List<Color> Colors,
	List<ActiveStateDto>? ActiveStates,
	byte[]? Image);
