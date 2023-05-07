using PetProfileDomain.Domain.Aggregates.ColorAggregate;

namespace PetProfileDomain.Application.Queries.Colors;

public record ColorsQueryResult(List<Color> Results);
