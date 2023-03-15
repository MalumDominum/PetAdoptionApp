using Mapster;
using PetAdoptionApp.Api.Models;
using PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PetProfilePageRequest, FilterablePagePetsQuery>()
              .Map(dest => dest.Filtering, src => src);
    }
}
