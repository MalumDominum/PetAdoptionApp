using ErrorOr;
using MediatR;
using PetProfileDomain.Application.Commands.Pets.Common;
using PetProfileDomain.Application.Queries.Pets.Commands.Models;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Application.Commands.Pets.Create;

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
