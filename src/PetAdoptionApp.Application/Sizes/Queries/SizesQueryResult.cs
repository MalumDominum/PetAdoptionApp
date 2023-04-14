using PetAdoptionApp.Domain.Aggregates.SizeAggregate;

namespace PetAdoptionApp.Application.Sizes.Queries;

public record SizesQueryResult(List<Size> Results);
