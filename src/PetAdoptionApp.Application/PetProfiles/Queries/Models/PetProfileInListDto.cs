using PetAdoptionApp.Domain.Aggregates.ColorAggregate;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Models;

public record PetProfileInListDto(
	Guid Id,
	string Name,
	string Gender,
	List<Color> Colors);
