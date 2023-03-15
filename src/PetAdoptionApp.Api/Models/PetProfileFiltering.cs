using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Api.Models;

public record PetProfileFiltering(
	//Guid? UserId,
	string NameLike,
	Gender Gender);
