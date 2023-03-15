using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Api.Models;

public record PetProfilePageRequest(
	DateTime? FromTime,
	//Guid? UserId,
	string? NameLike,
	Gender? Gender);
