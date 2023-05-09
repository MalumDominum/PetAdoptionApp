namespace AuthProvider.Api.Models;

public record UpdateUserRequest(
	Guid Id,
	string FirstName,
	string LastName);
	//Gender Gender);
