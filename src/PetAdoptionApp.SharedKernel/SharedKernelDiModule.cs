using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PetAdoptionApp.SharedKernel.DomainEvents;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetAdoptionApp.SharedKernel.Validation;

namespace PetAdoptionApp.SharedKernel;
public static class SharedKernelDiModule
{
	public static IServiceCollection AddSharedKernel(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuth(configuration)
				.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
				.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>()
				.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
		return services;
	}

	private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
				options =>
				{
					configuration.Bind("JwtSettings", options);
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(GetJwtSecretKey(configuration)),
						ValidateLifetime = true,
						ValidateAudience = false,
						ValidateIssuer = false,
						ClockSkew = TimeSpan.Zero
					};
				});
		return services;
	}

	private static byte[] GetJwtSecretKey(IConfiguration config) =>
		Encoding.ASCII.GetBytes(config.GetValue<string>("JwtSettings:SecretKey") ?? "");
}
