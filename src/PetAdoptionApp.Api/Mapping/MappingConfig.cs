using Mapster;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Create;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using static System.String;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PagePetProfileRequest, FilterablePagePetsQuery>()
	        .Map(dest => dest.Filtering, src => src);

        config.NewConfig<CreatePetCommand, PetProfile>();

		config.NewConfig<Gender, string>()
	        .Map(dest => dest, src => src.Value);

        config.NewConfig<string, Gender>()
	        .MapWith(src => Gender.List.Select(g => g.Value).Contains(src)
		        ? Gender.FromValue(src)
		        : Gender.Unknown);

		config.NewConfig<string, Gender?>()
	        .MapWith(src => !IsNullOrEmpty(src)
		        ? (Gender.List.Select(g => g.Value).Contains(src)
			        ? Gender.FromValue(src)
			        : Gender.Unknown)
		        : null);
	}
}
