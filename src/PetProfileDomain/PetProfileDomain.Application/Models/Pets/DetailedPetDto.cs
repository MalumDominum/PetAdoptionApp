using PetProfileDomain.Application.Models.Models.Nesting;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Application.Models.Models;

public record DetailedPetDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	SpeciesWithoutNestingDto Species,
	List<Color> Colors,
	PetDetailsQueryDto Details,
	SeparatedStates States,
	string Description,
	DateTime CreatedAt,
	DateTime? EditedAt);
