using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AuthProvider.Application.Queries.Users.Page;

public record PageUsersQuery(
	int? PageNumber,
	HttpRequest Request) : IRequest<ErrorOr<PageUsersQueryResult>>;
