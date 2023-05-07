namespace PetProfileDomain.Application.Models.Models;

public record SpeciesDto(int Id, string Title, List<BreedDto> Breeds);
