using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Species;

public record SpeciesQuery : IRequest<ErrorOr<SpeciesQueryResult>>;
