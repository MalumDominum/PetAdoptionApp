using Ardalis.ListStartupServices;
using PetAdoptionApp.Infrastructure;
using FastEndpoints;
using Serilog;
using PetAdoptionApp.Api;
using PetAdoptionApp.SharedKernel;
using PetAdoptionApp.Infrastructure.DataAccess;
using PetAdoptionApp.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddPresentation()
					.AddApplication()
					.AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment())
					.AddSharedKernel();

var app = builder.Build();
{
	if (app.Environment.IsDevelopment())
	{
		//app.UseDeveloperExceptionPage(); To see exception details
		app.UseShowAllServicesMiddleware();
	}
	else
	{
		app.UseExceptionHandler("/Error");
		app.UseHsts();
	}
	app.UseRouting();
	app.UseFastEndpoints();

	app.UseHttpsRedirection();
	app.UseStaticFiles();
	app.UseCookiePolicy();

	// Enable middleware to serve generated Swagger as a JSON endpoint.
	app.UseSwagger();

	// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Adoption API V1"));

	// Seed Database
	using (var scope = app.Services.CreateScope())
	{
		var services = scope.ServiceProvider;

		try
		{
			var context = services.GetRequiredService<AppDbContext>();
			//                                        context.Database.Migrate();
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
