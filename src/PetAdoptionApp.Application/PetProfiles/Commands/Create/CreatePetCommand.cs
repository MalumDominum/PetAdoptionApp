using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public record CreatePetCommand(
	string Name,
	Gender Gender,
	string Description,
	List<int>? ColorIds) : IRequest<ErrorOr<CreatePetCommandResult>>;
