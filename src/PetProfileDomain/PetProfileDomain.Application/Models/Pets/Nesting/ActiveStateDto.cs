using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Application.Models.Pets.Nesting;

public record ActiveStateDto(
	Status Status,
	DateTime AssignedTime);
