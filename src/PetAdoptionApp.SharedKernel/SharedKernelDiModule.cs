using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using PetAdoptionApp.SharedKernel.Behaviors;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetAdoptionApp.SharedKernel.Events;

namespace PetAdoptionApp.SharedKernel;
public static class SharedKernelDiModule
{
	public static IServiceCollection AddSharedKernel(this IServiceCollection services)
	{
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
		services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
		return services;
	}
}
