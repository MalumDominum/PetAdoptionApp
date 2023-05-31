using PetProfileDomain.Application.Models.Pets;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Api.Models;

public record PutPetRequest(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	string Description,
	int SpeciesId,
	int? SizeId,
	List<int>? ColorIds,
	PetDetailsCommandDto Details,
	List<byte[]>? Images,
	List<int>? States);
