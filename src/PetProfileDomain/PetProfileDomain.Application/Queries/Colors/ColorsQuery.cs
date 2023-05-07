using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Colors;

public record ColorsQuery : IRequest<ErrorOr<ColorsQueryResult>>;
