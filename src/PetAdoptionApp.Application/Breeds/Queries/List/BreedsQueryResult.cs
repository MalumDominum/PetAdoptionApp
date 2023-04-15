using PetAdoptionApp.Domain.Aggregates.BreedAggregate;

namespace PetAdoptionApp.Application.Breeds.Queries.List;

public record BreedsQueryResult(List<Breed> Results);
