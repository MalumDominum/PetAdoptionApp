namespace PetProfileDomain.Application.Models.Species;

public record SpeciesDto(int Id, string Title, List<BreedDto> Breeds);
