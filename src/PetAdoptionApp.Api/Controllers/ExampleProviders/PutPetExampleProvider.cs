using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using Swashbuckle.AspNetCore.Filters;

namespace PetAdoptionApp.Api.Controllers.ExampleProviders;

public class PutPetExampleProvider : IExamplesProvider<PutPetProfileRequest>
{
	public PutPetProfileRequest GetExamples() => new(
			Id: Guid.Empty,
			Name: "Fluffy",
			Gender: Gender.Male,
			BirthDate: new PartialPossibleDate(2020, 12, 21, true),
			Description: "Small fuzzy dog",
			SpeciesId: 2,
			SizeId: 1,
			ColorIds: new List<int> { 1, 5 },
			Details: new PetProfileDetailsCommandDto(
				BreedId: null,
				Neutering: true,
				Healthy: true,
				Vaccination: false,
				HasPassport: false,
				HasCollar: null),
			States: new List<int> { 2 }
		);
}
