using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Breeds.Queries.List;

public record BreedsQuery : IRequest<ErrorOr<BreedsQueryResult>>;
