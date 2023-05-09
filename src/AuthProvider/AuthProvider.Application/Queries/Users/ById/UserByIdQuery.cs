using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Queries.Users.ById;

public record UserByIdQuery(Guid Id) : IRequest<ErrorOr<UserByIdQueryResult>>;
