using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Application.Pets.Queries.Models.Nesting;

public record HistoryStateDto(
	Status Status,
	DateTime AssignedTime,
	DateTime ResolvedDate);
