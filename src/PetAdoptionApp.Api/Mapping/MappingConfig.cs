using Mapster;

namespace PetAdoptionApp.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        //    .Map(dest => dest.Token, src => src.Token)
        //    .Map(dest => dest, src => src.User);
    }
}
