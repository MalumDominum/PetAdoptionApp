using AuthProvider.Domain.Aggregates.UserAggregate.Entities;

namespace AuthProvider.Api.Models;

public record AuthenticateResponse(
	Guid UserId,
	string Token,
	string FirstName,
	List<Permission> Permissions);
