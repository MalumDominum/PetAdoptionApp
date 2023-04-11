using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public record UpdatePetCommand(
	Guid Id,
	string Name,
	Gender Gender,
	string Description,
	List<int>? ColorIds) : IRequest<ErrorOr<UpdatePetCommandResult>>;
