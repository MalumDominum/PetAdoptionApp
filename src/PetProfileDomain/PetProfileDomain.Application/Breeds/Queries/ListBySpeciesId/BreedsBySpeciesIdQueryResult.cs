using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Application.Breeds.Queries.ListBySpeciesId;

public record BreedsBySpeciesIdQueryResult(List<Breed> Results);
