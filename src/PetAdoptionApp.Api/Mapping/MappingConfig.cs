using Mapster;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PetProfilePageRequest, FilterablePagePetsQuery>()
              .Map(dest => dest.Filtering, src => src);

        config.NewConfig<PetProfile, PetProfileListDto>()
	        .Map(dest => dest.Gender, src => src.Gender.Value);

        config.NewConfig<PetProfileListDto, PetProfile>()
	        .Map(dest => dest.Gender.Value, src => src.Gender);
	}
}
