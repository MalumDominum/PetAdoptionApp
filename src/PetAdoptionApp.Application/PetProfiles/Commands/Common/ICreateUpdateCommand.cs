using PetAdoptionApp.Application.PetProfiles.Commands.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Shared;

public interface ICreateUpdatePetCommand
{
	public string Name { get; init; }
	public Gender Gender { get; init; }
	public PartialPossibleDate BirthDate { get; init; }
	public string Description { get; init; }
	public int SpeciesId { get; init; }
	public int SizeId { get; init; }
	public List<int>? ColorIds { get; init; }
	public PetProfileDetailsCommandDto Details { get; init; }
	public List<int>? States { get; init; }
}
