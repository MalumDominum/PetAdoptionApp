using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Pets.ById;

public record PetByIdQuery(Guid Id) : IRequest<ErrorOr<PetByIdQueryResult>>;
