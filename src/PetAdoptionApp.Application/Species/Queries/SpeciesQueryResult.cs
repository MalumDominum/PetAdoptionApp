namespace PetAdoptionApp.Application.Species.Queries;

public record SpeciesQueryResult(
	List<Domain.Aggregates.SpeciesAggregate.Species> Results);
