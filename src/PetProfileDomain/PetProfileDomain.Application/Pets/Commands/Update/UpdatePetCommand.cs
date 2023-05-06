using ErrorOr;
using MediatR;
using PetProfileDomain.Application.Pets.Commands.Common;
using PetProfileDomain.Application.Pets.Commands.Models;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Application.Pets.Commands.Update;

public record UpdatePetCommand(
	Guid Id,
	string Name,
	Gender Gender,
	string Description,
	PartialPossibleDate BirthDate,
	int SpeciesId,
	int? SizeId,
	List<int>? ColorIds,
	PetDetailsCommandDto Details,
	List<int>? States) : IRequest<ErrorOr<UpdatePetCommandResult>>, ICreateUpdatePetCommand;
