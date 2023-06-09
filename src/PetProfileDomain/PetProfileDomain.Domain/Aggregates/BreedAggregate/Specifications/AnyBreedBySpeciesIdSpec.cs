﻿using Ardalis.Specification;

namespace PetProfileDomain.Domain.Aggregates.BreedAggregate.Specifications;

public sealed class AnyBreedBySpeciesIdSpec : Specification<Breed>
{
	public AnyBreedBySpeciesIdSpec(int speciesId, int breedId) => Query.Where(b => b.SpeciesId == speciesId && b.Id == breedId);
}
