using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.Breeds.Queries.List;

public record BreedsQuery : IRequest<ErrorOr<BreedsQueryResult>>;
