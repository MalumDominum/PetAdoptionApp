using PetAdoptionApp.Application.Species.Models;

namespace PetAdoptionApp.Application.Species.Queries;

public record SpeciesQueryResult(
	List<SpeciesDto> Results);
