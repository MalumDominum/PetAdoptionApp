using PetProfileDomain.Application.Models.Species;

namespace PetProfileDomain.Application.Queries.Species;

public record SpeciesQueryResult(
	List<SpeciesDto> Results);
