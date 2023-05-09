using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Queries.Users.Search;

public record SearchUsersQuery(string SearchValue) : IRequest<ErrorOr<SearchUsersQueryResult>>;
