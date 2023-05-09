using AuthProvider.Application.Models;

namespace AuthProvider.Application.Queries.Users.Search;

public record SearchUsersQueryResult(List<InListUserDto> Users);
