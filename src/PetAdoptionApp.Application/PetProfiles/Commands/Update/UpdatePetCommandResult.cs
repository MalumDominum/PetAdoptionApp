using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public record UpdatePetCommandResult(
	string Name,
	Gender Gender);
