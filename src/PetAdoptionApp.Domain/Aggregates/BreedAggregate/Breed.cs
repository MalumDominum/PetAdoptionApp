﻿using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.BreedAggregate;

public class Breed : EntityBase<int>, IAggregateRoot
{
	public string Name { get; set; } = null!;
}
