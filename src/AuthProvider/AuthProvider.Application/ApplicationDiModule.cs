using System.Reflection;
using AuthProvider.Application.Services;
using AuthProvider.Application.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.SharedKernel.Providers;

namespace AuthProvider.Application;

public static class ApplicationDiModule
{
	public static IServiceCollection AddApplication(this IServiceCollection services,
		ConfigurationManager configuration)
	{
		services.AddMediatR(config =>
			config.RegisterServicesFromAssembly(typeof(ApplicationDiModule).Assembly));

		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		services.AddSingleton<IDateTimeProvider, DateTimeProviderWithoutTimezone>();
		services.AddSingleton<ITokenProviderService, TokenProviderService>();

		return services;
	}
}
