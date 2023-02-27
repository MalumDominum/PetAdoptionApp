using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.Application.Interfaces;
using PetAdoptionApp.Application.Services;
using PetAdoptionApp.SharedKernel.Behaviors;

namespace PetAdoptionApp.Application;
public static class ApplicationDiModule
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddServices();

		services.AddMediatR(configuration =>
			configuration.RegisterServicesFromAssemblies(typeof(ApplicationDiModule).Assembly));

		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}

	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddScoped<IToDoItemSearchService, ToDoItemSearchService>();
		services.AddScoped<IDeleteContributorService, DeleteContributorService>();

		return services;
	}
}
