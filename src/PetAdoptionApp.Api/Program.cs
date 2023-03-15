using Ardalis.ListStartupServices;
using PetAdoptionApp.Infrastructure;
using Serilog;
using PetAdoptionApp.Api;
using PetAdoptionApp.SharedKernel;
using PetAdoptionApp.Infrastructure.DataAccess;
using PetAdoptionApp.Application;

var builder = WebApplication.CreateBuilder(args);
var isDev = builder.Environment.IsDevelopment();
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddPresentation(isDev)
				.AddApplication()
				.AddInfrastructure(builder.Configuration, isDev)
				.AddSharedKernel();

var app = builder.Build();
{
	if (isDev)
	{
		app.UseDeveloperExceptionPage();
		app.UseShowAllServicesMiddleware();
	}
	else
	{
		app.UseExceptionHandler("/Error");
		app.UseHttpsRedirection();
		app.UseHsts();
	}
	app.UseRouting();

	//app.UseStaticFiles(); Add if will share files

	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Adoption API V1"));

	// Seed Database
	using (var scope = app.Services.CreateScope())
	{
		var services = scope.ServiceProvider;

		try
		{
			var context = services.GetRequiredService<AppDbContext>();
			//context.Database.Migrate();
			context.Database.EnsureCreated();
			SeedData.Initialize(services);
		}
		catch (Exception ex)
		{
			var logger = services.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
		}
	}
	app.Run();
}
