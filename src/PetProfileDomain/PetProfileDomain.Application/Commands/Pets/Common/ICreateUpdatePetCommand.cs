using PetProfileDomain.Application.Models.Pets;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

namespace PetProfileDomain.Application.Commands.Pets.Common;

public interface ICreateUpdatePetCommand
{
	public string Name { get; init; }
	public Gender Gender { get; init; }
	public PartialPossibleDate BirthDate { get; init; }
	public string Description { get; init; }
	public int SpeciesId { get; init; }
	public int? SizeId { get; init; }
	public List<int>? ColorIds { get; init; }
	public PetDetailsCommandDto Details { get; init; }
	public List<int>? States { get; init; }
}
