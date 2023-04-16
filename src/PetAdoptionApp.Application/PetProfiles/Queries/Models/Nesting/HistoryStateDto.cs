using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;

public record HistoryStateDto(
	Status Status,
	DateTime AssignedTime,
	DateTime ResolvedDate);
