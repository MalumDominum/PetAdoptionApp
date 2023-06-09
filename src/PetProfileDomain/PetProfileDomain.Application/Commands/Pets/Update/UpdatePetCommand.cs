﻿using ErrorOr;
using MediatR;
using PetProfileDomain.Application.Commands.Pets.Common;
using PetProfileDomain.Application.Models.Pets;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Application.Commands.Pets.Update;

public record UpdatePetCommand(
	Guid Id,
	string Name,
	Gender Gender,
	string Description,
	PartialPossibleDate BirthDate,
	int SpeciesId,
	int? SizeId,
	List<int>? ColorIds,
	List<Image>? Images,
	PetDetailsCommandDto Details,
	List<int>? States) : IRequest<ErrorOr<UpdatePetCommandResult>>, ICreateUpdatePetCommand
{
	public Guid OwnerId { get; set; }

	public UpdatePetCommand() : this(Guid.Empty, null!, null!, null!, null!, 0, null, null!, null, null!, null) { }
}
