using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Breeds.List;

public record BreedsQuery : IRequest<ErrorOr<BreedsQueryResult>>;
