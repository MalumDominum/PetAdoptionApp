using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Species.Queries;

public record SpeciesQuery : IRequest<ErrorOr<SpeciesQueryResult>>;
