using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PetAdoptionApp.SharedKernel;
public static class SharedKernelDiModule
{
	public static IServiceCollection AddSharedKernel(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		return services;
	}
}
