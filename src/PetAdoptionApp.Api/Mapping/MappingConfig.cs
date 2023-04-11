using Mapster;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PetProfilePageRequest, FilterablePagePetsQuery>()
              .Map(dest => dest.Filtering, src => src);

        config.NewConfig<Gender, string>()
	        .Map(dest => dest, src => src.Value);

        config.NewConfig<string, Gender>()
	        .MapWith(src => src == null ? Gender.Unknown : Gender.FromValue(src));
	}
}
