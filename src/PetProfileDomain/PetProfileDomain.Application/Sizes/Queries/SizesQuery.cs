using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Sizes.Queries;

public record SizesQuery : IRequest<ErrorOr<SizesQueryResult>>;
