using AuthProvider.Domain.Aggregates.UserAggregate.Entities;
using AuthProvider.Domain.Aggregates.UserAggregate.Enums;

namespace AuthProvider.Application.Models;

public record FullUserDto(
	Guid Id,
	string Email,
	string FirstName,
	string LastName,
	Gender Gender,
	List<Permission> Permissions,
	DateTime RegistrationTime);
