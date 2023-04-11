using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public record CreatePetCommandResult(
	Guid Id,
	string Name,
	Gender Gender);
