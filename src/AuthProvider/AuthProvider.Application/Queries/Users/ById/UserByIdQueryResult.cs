using AuthProvider.Application.Models;

namespace AuthProvider.Application.Queries.Users.ById;

public record UserByIdQueryResult(DetailedUserDto User);
