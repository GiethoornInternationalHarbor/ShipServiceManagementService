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

namespace ShipServiceManagement.App
{
	public class Startup
	{
		public Startup()
		{
			string filePath = ".env";

#if DEBUG
			filePath = Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("bin")), filePath);
#endif

			DotEnv.Config(throwOnError: false, filePath: filePath);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			IConfiguration cfg = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.Build();

			services.AddLogic();
			services.AddMessaging(cfg);
			services.AddPersistence(cfg);
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
