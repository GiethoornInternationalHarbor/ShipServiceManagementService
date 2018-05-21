using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipServiceManagement.Logic.Extensions;
using ShipServiceManagement.Messaging.Extensions;
using ShipServiceManagement.Persistence.Extensions;
using dotenv.net;
using System.IO;
using System;
using Utf8Json.Resolvers;
using ShipServiceManagement.Logic.Interfaces;
using ShipServiceManagement.App.Seed;

namespace ShipServiceManagement.App
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			string filePath = ".env";

#if DEBUG
			filePath = Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("bin")), filePath);
#endif

			DotEnv.Config(throwOnError: false, filePath: filePath);
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLogic();
			services.AddMessaging(Configuration);
			services.AddPersistence(Configuration);
			services.AddMvc();
		}

		public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			CompositeResolver.RegisterAndSetAsDefault(new[]
			{
			   EnumResolver.UnderlyingValue,
			   StandardResolver.ExcludeNullCamelCase
			});

			await Persistence.Extensions.DIHelper.OnServicesSetup(app.ApplicationServices);

			// Seed initial shipservices 
			var shipServiceManager = app.ApplicationServices.GetService<IShipServiceManager>();

			var shipServices = await shipServiceManager.GetShipServices();
			if (shipServices.Count == 0)
			{
				SeedHelper.Seed(shipServiceManager);
			}

			app.UseMvc();
		}
	}
}
