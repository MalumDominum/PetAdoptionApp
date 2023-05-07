using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Application.Models.Models.Nesting;

public record ActiveStateDto(
	Status Status,
	DateTime AssignedTime);
