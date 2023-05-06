using PetProfileDomain.Application.Species.Models;

namespace PetProfileDomain.Application.Species.Queries;

public record SpeciesQueryResult(
	List<SpeciesDto> Results);
