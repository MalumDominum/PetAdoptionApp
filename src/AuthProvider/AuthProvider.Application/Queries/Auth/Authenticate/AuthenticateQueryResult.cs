using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate.Entities;

namespace AuthProvider.Application.Queries.Auth.Authenticate;

public record AuthenticateQueryResult(
	Guid Id,
	Token Token,
	string LastName,
	string FirstName,
	List<Permission> Permissions);
