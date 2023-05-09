namespace AuthProvider.Application.Models;

public record Token(
	string AccessToken,
	DateTime ExpiresAt);
