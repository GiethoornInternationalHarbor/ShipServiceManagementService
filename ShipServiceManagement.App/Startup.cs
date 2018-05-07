using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipServiceManagement.Logic.Extensions;
using ShipServiceManagement.Messaging.Extensions;
using ShipServiceManagement.Persistence.Extensions;
using System;	

namespace ShipServiceManagement.App
{
	public static class Startup
    {
		public static IServiceProvider ServiceProvider { get; private set; }

		public static void Start()
		{
			string filePath = ".env";	  			

			DotEnv.Config(throwOnError: false, filePath: filePath);

			var serviceCollection = new ServiceCollection();

			ConfigureServices(serviceCollection);

			ServiceProvider = serviceCollection.BuildServiceProvider();	 
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			IConfiguration cfg = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.Build();

			services.AddLogic();
			services.AddMessaging();
			services.AddPersistence(cfg);
		}
    }
}
