using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Breeds.ListBySpeciesId;

public record BreedsBySpeciesIdQuery(int SpeciesId) : IRequest<ErrorOr<BreedsBySpeciesIdQueryResult>>;
