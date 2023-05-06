using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Colors.Queries;

public record ColorsQuery : IRequest<ErrorOr<ColorsQueryResult>>;
