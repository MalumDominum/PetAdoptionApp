using ErrorOr;
using MediatR;
using PetProfileDomain.Application.Pets.Commands.Common;
using PetProfileDomain.Application.Pets.Commands.Models;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Application.Pets.Commands.Create;

public record CreatePetCommand(
	string Name,
	Gender Gender,
	PartialPossibleDate BirthDate,
	string Description,
	int SpeciesId,
	int? SizeId,
	List<int>? ColorIds,
	PetDetailsCommandDto Details,
	List<int>? States) : IRequest<ErrorOr<CreatePetCommandResult>>, ICreateUpdatePetCommand;
