using ErrorOr;
using MediatR;
using PetAdoptionApp.Application.PetProfiles.Commands.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public record CreatePetCommand(
	string Name,
	Gender Gender,
	PartialPossibleDate BirthDate,
	string Description,
	int SpeciesId,
	int SizeId,
	List<int>? ColorIds,
	PetProfileDetailsCommandDto Details) : IRequest<ErrorOr<CreatePetCommandResult>>;
