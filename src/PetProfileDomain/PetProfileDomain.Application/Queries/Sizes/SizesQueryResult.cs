using PetProfileDomain.Domain.Aggregates.SizeAggregate;

namespace PetProfileDomain.Application.Queries.Sizes;

public record SizesQueryResult(List<Size> Results);
