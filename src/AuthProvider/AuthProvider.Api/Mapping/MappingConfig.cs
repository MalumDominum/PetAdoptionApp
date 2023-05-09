using Mapster;
using PetAdoptionApp.SharedKernel.Providers;

namespace AuthProvider.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        
	}

	private static DateTime UtcNow() => MapContext.Current.GetService<IDateTimeProvider>().UtcNow;
}
