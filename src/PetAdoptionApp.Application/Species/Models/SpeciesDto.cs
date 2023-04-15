namespace PetAdoptionApp.Application.Species.Models;

public record SpeciesDto(int Id, string Title, List<BreedDto> Breeds);
