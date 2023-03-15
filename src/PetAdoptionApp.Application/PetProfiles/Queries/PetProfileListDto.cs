using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Queries;

public record PetProfileListDto(
	string Name,
	Gender Gender);
