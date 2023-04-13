using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Api.Models;

public record PostPetProfilePageResponse(
	DateTime? FromTime,
	Guid? UserId,
	PartialPossibleDate BirthDate,
	string? NameLike,
	Gender? Gender);
