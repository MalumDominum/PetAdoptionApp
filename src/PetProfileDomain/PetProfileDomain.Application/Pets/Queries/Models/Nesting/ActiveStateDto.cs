using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Application.Pets.Queries.Models.Nesting;

public record ActiveStateDto(
	Status Status,
	DateTime AssignedTime);
