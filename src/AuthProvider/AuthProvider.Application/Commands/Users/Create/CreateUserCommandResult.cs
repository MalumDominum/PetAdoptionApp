using AuthProvider.Application.Models;

namespace AuthProvider.Application.Commands.Users.Create;

public record RegisterCommandResult(Guid Id, Token Token);
