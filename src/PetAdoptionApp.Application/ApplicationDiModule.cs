using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PetAdoptionApp.Application;

public static class ApplicationDiModule
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		//services.AddServices();

		services.AddMediatR(configuration =>
			configuration.RegisterServicesFromAssembly(typeof(ApplicationDiModule).Assembly));

		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}

	//public static IServiceCollection AddServices(this IServiceCollection services) => services;
}
