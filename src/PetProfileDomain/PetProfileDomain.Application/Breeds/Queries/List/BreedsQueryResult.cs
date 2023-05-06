using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Application.Breeds.Queries.List;

public record BreedsQueryResult(List<Breed> Results);
