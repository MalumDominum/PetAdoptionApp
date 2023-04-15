using Mapster;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Commands.Create;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;
using PetAdoptionApp.Application.PetProfiles.Queries.Models.Nesting;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.StateAggregate;
using static System.String;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PagePetProfileRequest, FilterablePagePetsQuery>()
	        .Map(dest => dest.Filtering, src => src);

        config.NewConfig<PetProfile, PetProfileInListDto>()
	        .Map(dest => dest.ActiveStates, src => src.States);

		config.NewConfig<List<State>?, States> ()
	        .MapWith(src => src != null 
		        ? new States(src.Where(s => s.ResolvedDate == null).ToList(),
						     src.Where(s => s.ResolvedDate != null).ToList())
		        : new States());

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
