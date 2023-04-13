using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public record CreatePetCommand(
	string Name,
	Gender Gender,
	PartialPossibleDate BirthDate,
	string Description,
	List<int>? ColorIds) : IRequest<ErrorOr<CreatePetCommandResult>>;
