using PetProfileDomain.Application.Models.Pets.Nesting;
using PetProfileDomain.Application.Models.Species;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Entities;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;

namespace PetProfileDomain.Application.Models.Pets;

public record DetailedPetDto(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	SpeciesWithoutNestingDto Species,
	Size Size,
	List<Color> Colors,
	PetDetailsQueryDto Details,
	List<Image>? Images,
	SeparatedStates States,
	List<TransferFact> TransferHistory,
	Guid OwnerId,
	string Description,
	DateTime CreatedAt,
	DateTime? EditedAt);
