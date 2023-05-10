using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Queries.Users.Page;

public record PageUsersQuery(int? PageNumber) : IRequest<ErrorOr<PageUsersQueryResult>>;
