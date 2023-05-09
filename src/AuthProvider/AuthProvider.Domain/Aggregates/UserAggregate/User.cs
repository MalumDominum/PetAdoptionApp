using AuthProvider.Domain.Aggregates.UserAggregate.Enums;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace AuthProvider.Domain.Aggregates.UserAggregate;

public class User : EntityBase<Guid>, IAggregateRoot
{
	public string Email { get; set; } = null!;

	public byte[] PasswordHash { get; set; } = null!;

	public byte[] PasswordSalt { get; set; } = null!;

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	//public Gender Gender { get; set; } = null!;

	public DateTime RegistrationTime { get; set; }
}
