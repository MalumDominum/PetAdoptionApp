namespace AuthProvider.Api.Models;

public record RegisterResponse(
	Guid UserId,
	string Token,
	string FirstName,
	string LastName);
