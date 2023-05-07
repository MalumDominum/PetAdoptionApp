using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Sizes;

public record SizesQuery : IRequest<ErrorOr<SizesQueryResult>>;
