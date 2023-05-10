using AuthProvider.Domain.Aggregates.UserAggregate.Enums;

namespace AuthProvider.Application.Models;

public record DetailedUserDto(
	Guid Id,
	string FirstName,
	string LastName,
	Gender Gender);
