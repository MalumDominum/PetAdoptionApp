using AuthProvider.Application.Models;

namespace AuthProvider.Application.Commands.Users.Create;

public record CreateUserCommandResult(Guid Id, Token Token);
