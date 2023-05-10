using Ardalis.SmartEnum;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Enums;

public class Role : SmartEnum<Role, int>
{
	public static readonly Role User = new(nameof(User), 0);
	public static readonly Role RootAdmin = new(nameof(RootAdmin), 1);
	public static readonly Role Admin = new(nameof(Admin), 2);
	public static readonly Role Manager = new(nameof(Manager), 3);
	public static readonly Role Volunteer = new(nameof(Volunteer), 4);

	private Role(string name, int value) : base(name, value) { }
}
