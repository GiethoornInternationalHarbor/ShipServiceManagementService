using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipServiceManagement.Messaging.Interfaces;
using ShipServiceManagement.Persistence.Database;
using ShipServiceManagement.Persistence.Implementations;
using ShipServiceManagement.Persistence.Interfaces;
using System;

namespace ShipServiceManagement.Persistence.Extensions
{
	public static class DIHelper
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuation)
		{
			services.AddDbContext<ShipServiceDbContext>(opt => opt.UseSqlServer(configuation.GetSection("DB_CONNECTION_STRING").Value));

			services.AddTransient<IShipServiceService, ShipServiceService>();

			return services;
		}

		public async static void OnServicesSetup(IServiceProvider serviceProvider)
		{

			using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				Console.WriteLine("Connecting to database and migrating if required");
				var dbContext = serviceScope.ServiceProvider.GetService<ShipServiceDbContext>();
				var messagePublisher = serviceScope.ServiceProvider.GetService<IMessagePublisher>();
				await dbContext.Database.MigrateAsync();
				Console.WriteLine("Completed connecting to database");
				Console.WriteLine("Start seeding database");
				dbContext = serviceScope.ServiceProvider.GetService<ShipServiceDbContext>();
				SeedHelper.Seed(dbContext, messagePublisher);
				Console.WriteLine("Seeding database completed");
			}
		}
	}
}
