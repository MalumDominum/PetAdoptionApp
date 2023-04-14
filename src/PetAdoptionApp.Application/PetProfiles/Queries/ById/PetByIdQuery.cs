using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.PetProfiles.Queries.ById;

public record PetByIdQuery(Guid Id) : IRequest<ErrorOr<PetByIdQueryResult>>;
