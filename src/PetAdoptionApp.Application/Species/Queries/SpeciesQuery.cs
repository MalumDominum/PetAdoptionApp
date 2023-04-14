using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.Species.Queries;

public record SpeciesQuery : IRequest<ErrorOr<SpeciesQueryResult>>;
