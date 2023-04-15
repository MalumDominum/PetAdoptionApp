using PetAdoptionApp.Domain.Aggregates.BreedAggregate;

namespace PetAdoptionApp.Application.Breeds.Queries.ListBySpeciesId;

public record BreedsBySpeciesIdQueryResult(List<Breed> Results);
