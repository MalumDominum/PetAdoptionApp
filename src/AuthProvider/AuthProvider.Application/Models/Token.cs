namespace AuthProvider.Application.Models;

public record Token(
	string Value,
	DateTime ExpiresAt);
