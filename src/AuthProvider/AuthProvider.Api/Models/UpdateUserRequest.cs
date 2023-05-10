namespace AuthProvider.Api.Models;

public record UpdateUserRequest(
	Guid Id,
	string FirstName,
	string LastName,
	string Gender);
