using PetProfileDomain.Domain.Aggregates.BreedAggregate;

namespace PetProfileDomain.Application.Queries.Breeds.List;

public record BreedsQueryResult(List<Breed> Results);
