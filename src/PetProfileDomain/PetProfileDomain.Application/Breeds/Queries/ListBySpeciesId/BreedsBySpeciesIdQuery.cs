using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Breeds.Queries.ListBySpeciesId;

public record BreedsBySpeciesIdQuery(int SpeciesId) : IRequest<ErrorOr<BreedsBySpeciesIdQueryResult>>;
