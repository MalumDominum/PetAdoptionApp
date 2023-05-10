namespace AuthProvider.Api.Models;

public record UpdateUserByOwnerRequest(
	string FirstName,
	string LastName,
	string Gender);
