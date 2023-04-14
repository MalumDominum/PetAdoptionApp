using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public record UpdatePetCommand(
	Guid Id,
	string Name,
	Gender Gender,
	string Description,
	PartialPossibleDate BirthDate,
	int SpeciesId,
	int SizeId,
	List<int>? ColorIds) : IRequest<ErrorOr<UpdatePetCommandResult>>;
