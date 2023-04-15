using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.Breeds.Queries.ListBySpeciesId;

public record BreedsBySpeciesIdQuery(int SpeciesId) : IRequest<ErrorOr<BreedsBySpeciesIdQueryResult>>;
