using Ocelot.DependencyInjection;
using Ocelot.Middleware;

new WebHostBuilder()
	.UseKestrel()
	.UseContentRoot(Directory.GetCurrentDirectory())
	.ConfigureAppConfiguration((hostingContext, config) =>
	{
		var env = hostingContext.HostingEnvironment;
		config.SetBasePath(env.ContentRootPath)
			  .AddJsonFile("appsettings.json", true, true)
			  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
			  .AddJsonFile($"ocelot.{env.EnvironmentName}.json", false, true)
			  .AddEnvironmentVariables();
	})
	.ConfigureServices(s => s.AddOcelot())
	.ConfigureLogging((hostingContext, logging) =>
	{
		//add your logging
	})
	.UseIISIntegration()
	.Configure(app => app.UseOcelot().Wait())
	.Build()
	.Run();
