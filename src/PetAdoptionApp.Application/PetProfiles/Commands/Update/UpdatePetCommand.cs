using ErrorOr;
using MediatR;
using PetAdoptionApp.Application.PetProfiles.Commands.Common;
using PetAdoptionApp.Application.PetProfiles.Commands.Models;
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
	int? SizeId,
	List<int>? ColorIds,
	PetProfileDetailsCommandDto Details,
	List<int>? States) : IRequest<ErrorOr<UpdatePetCommandResult>>, ICreateUpdatePetCommand;
