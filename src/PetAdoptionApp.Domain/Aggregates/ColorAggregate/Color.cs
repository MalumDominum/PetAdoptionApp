﻿using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.ColorAggregate;

public class Color : EntityBase<int>, IAggregateRoot
{
	public string Name { get; set; } = null!;

	public string HexValue { get; set; } = null!;
}
