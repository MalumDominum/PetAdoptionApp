using PetProfileDomain.Application.Models.Models;

namespace PetProfileDomain.Application.Queries.Species;

public record SpeciesQueryResult(
	List<SpeciesDto> Results);
