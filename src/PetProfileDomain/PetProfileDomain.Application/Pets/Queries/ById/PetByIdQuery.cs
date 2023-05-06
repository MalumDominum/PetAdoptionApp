using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Pets.Queries.ById;

public record PetByIdQuery(Guid Id) : IRequest<ErrorOr<PetByIdQueryResult>>;
