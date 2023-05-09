using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Application.Models.Pets.Nesting;

public record HistoryStateDto(
	Status Status,
	DateTime AssignedTime,
	DateTime ResolvedDate);
