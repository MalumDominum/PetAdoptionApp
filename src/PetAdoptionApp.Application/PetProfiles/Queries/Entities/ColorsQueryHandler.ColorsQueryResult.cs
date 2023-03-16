using PetAdoptionApp.Domain.Aggregates.ColorAggregate;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Entities;

public record ColorsQueryResult(List<Color> Results);
