using PetProfileDomain.Domain.Aggregates.ColorAggregate;

namespace PetProfileDomain.Application.Colors.Queries;

public record ColorsQueryResult(List<Color> Results);
