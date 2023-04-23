using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using Swashbuckle.AspNetCore.Filters;

namespace PetAdoptionApp.Api.Controllers.ExampleProviders;

public class PostPetExampleProvider : IExamplesProvider<PostPetProfileRequest>
{
	public PostPetProfileRequest GetExamples() => new(
			Name: "Luna",
			Gender: Gender.Female,
			BirthDate: new PartialPossibleDate(2023, 2, null, false),
			Description: "Cute little kitty",
			SpeciesId: 1,
			SizeId: 1,
			ColorIds: new List<int> { 1, 2, 3 },
			Details: new PetProfileDetailsCommandDto(
				BreedId: 3,
				Neutering: true,
				Healthy: false,
				Vaccination: true,
				HasPassport: false,
				HasCollar: true),
			States: new List<int> { 1, 5 }
		);
}
