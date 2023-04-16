using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;

public record ActiveStateDto(
	Status Status,
	DateTime AssignedTime);
