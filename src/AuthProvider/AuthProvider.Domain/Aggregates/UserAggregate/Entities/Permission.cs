using PetAdoptionApp.SharedKernel.Authorization.Enums;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace AuthProvider.Domain.Aggregates.UserAggregate.Entities;

public class Permission : EntityBase<Guid>
{
	public Role Role { get; set; } = null!;

	public Guid GrantedBy { get; set; }

	public DateTime GrantedTime { get; set; }

	public override string ToString() => Role.Name;
}
