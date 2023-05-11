using Ardalis.SmartEnum;

namespace PetAdoptionApp.SharedKernel.Authorization.Enums;

public class Role : SmartEnum<Role, int>
{
	private Role? Parent { get; }

	public static readonly Role User = new(nameof(User), 0);

	public static readonly Role RootAdmin = new(nameof(RootAdmin), 1);
	public static readonly Role Admin = new(nameof(Admin), 2, RootAdmin);
	public static readonly Role Manager = new(nameof(Manager), 3, Admin);

	public static readonly Role VetVolunteer = new(nameof(VetVolunteer), 10, Manager);
	public static readonly Role Volunteer = new(nameof(Volunteer), 11, Manager);

	public static readonly Role ShelterOwner = new(nameof(ShelterOwner), 20, Admin);
	public static readonly Role ShelterEmployee = new(nameof(ShelterEmployee), 21, ShelterOwner);

	private Role(string name, int value, Role? parent = null) : base(name, value) => Parent = parent;

	public bool HasLowerRank(Role anotherRole) => anotherRole.HasHigherRank(this);

	public bool HasHigherRank(Role anotherRole) =>
		this == RootAdmin || (this != anotherRole && HasHigherRankHelper(anotherRole));

	private bool HasHigherRankHelper(Role role) =>
		role.Parent != null && (role.Parent == this || HasHigherRankHelper(role.Parent));

	public static IEnumerable<Role> IncludeHighRanked(Role role)
	{
		var parent = role.Parent;

		while (parent != null)
		{
			yield return parent;
			parent = parent.Parent;
		}
	}
}
