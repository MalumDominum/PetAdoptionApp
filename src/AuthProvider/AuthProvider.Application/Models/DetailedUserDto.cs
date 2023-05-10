using AuthProvider.Domain.Aggregates.UserAggregate.Enums;

namespace AuthProvider.Application.Models;

public class DetailedUserDto
{
	public Guid Id { get; set; }
	
	public string FirstName { get; set; } = null!;
	
	public string LastName { get; set; } = null!;
	
	public Gender Gender { get; set; } = null!;
}
