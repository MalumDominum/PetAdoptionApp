﻿using PetAdoptionApp.Application.PetProfiles.Commands.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Api.Models;

public record PutPetProfileRequest(
	Guid Id,
	string Name,
	string Gender,
	PartialPossibleDate BirthDate,
	string Description,
	int SpeciesId,
	int SizeId,
	List<int>? ColorIds,
	PetProfileDetailsCommandDto Details);