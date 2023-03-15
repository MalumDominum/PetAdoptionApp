using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models;

public record PetProfileFilteringOptions(
	//Guid? UserId,
	string? NameLike,
	Gender? Gender);
