using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models;

public record PetProfileListDto(
	string Name,
	Gender Gender);
