using AuthProvider.Application.Commands.Users.Create;
using AuthProvider.Domain.Aggregates.UserAggregate;
using Mapster;
using PetAdoptionApp.SharedKernel.Providers;
using static BCrypt.Net.BCrypt;

namespace AuthProvider.Api.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateUserCommand, User>()
		    .Map(dest => dest.PasswordHash, src => HashPassword(src.Password))
			.AfterMapping(p => p.RegistrationTime = UtcNow());
    }

	private static DateTime UtcNow() => MapContext.Current.GetService<IDateTimeProvider>().UtcNow;
}
