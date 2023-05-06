using PetProfileDomain.Domain.Aggregates.SizeAggregate;

namespace PetProfileDomain.Application.Sizes.Queries;

public record SizesQueryResult(List<Size> Results);
