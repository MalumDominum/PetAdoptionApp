using ErrorOr;
using MediatR;

namespace AuthProvider.Application.Queries.Users.ByIdUndetailed;

public record UserByIdUndetailedQuery(Guid Id) : IRequest<ErrorOr<UserByIdUndetailedQueryResult>>;
