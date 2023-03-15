using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Commands;

public record PetProfileCommandResult(
	string Name,
	Gender Gender);
