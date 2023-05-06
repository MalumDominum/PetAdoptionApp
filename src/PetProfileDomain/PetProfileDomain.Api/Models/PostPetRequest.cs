using PetProfileDomain.Application.Pets.Commands.Models;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Api.Models;

public record PostPetRequest(
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	string Description,
	int SpeciesId,
	int? SizeId,
	List<int>? ColorIds,
	PetDetailsCommandDto Details,
	List<int>? States);
