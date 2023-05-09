using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Queries.Auth.Authenticate;

public record AuthenticateQuery(
	string Email,
	string Password) : IRequest<ErrorOr<AuthenticateQueryResult>>;
