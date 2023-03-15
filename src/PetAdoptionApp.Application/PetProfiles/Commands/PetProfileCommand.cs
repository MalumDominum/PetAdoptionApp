using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Application.PetProfiles.Commands;

public record PetProfileCommand(
	string Name,
	Gender Gender) : IRequest<ErrorOr<PetProfileCommandResult>>;
