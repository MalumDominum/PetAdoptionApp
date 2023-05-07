using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Application.Queries.Breeds.ListBySpeciesId;

public record BreedsBySpeciesIdQueryResult(List<Breed> Results);
