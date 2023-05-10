using AuthProvider.Application.Models;

namespace AuthProvider.Application.Queries.Users.Page;

public record PageUsersQueryResult(List<FullUserDto> Users);
