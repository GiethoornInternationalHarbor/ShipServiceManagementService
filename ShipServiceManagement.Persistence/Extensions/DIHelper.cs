using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipServiceManagement.Persistence.Database;
using ShipServiceManagement.Persistence.Implementations;
using ShipServiceManagement.Persistence.Interfaces;
using System;
using System.Threading.Tasks;

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

		public async static Task OnServicesSetup(IServiceProvider serviceProvider)
		{

			using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				Console.WriteLine("Connecting to database and migrating if required");
				var dbContext = serviceScope.ServiceProvider.GetService<ShipServiceDbContext>();
				await dbContext.Database.MigrateAsync();
				Console.WriteLine("Completed connecting to database");
			}
		}
	}
}
