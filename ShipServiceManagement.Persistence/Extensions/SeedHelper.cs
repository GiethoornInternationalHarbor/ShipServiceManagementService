using ShipServiceManagement.Models;
using ShipServiceManagement.Persistence.Database;
using System;
using System.Linq;

namespace ShipServiceManagement.Persistence.Extensions
{
	public static class SeedHelper
	{
		public static void Seed(ShipServiceDbContext dbContext)
		{
			if (!dbContext.ShipService.Any())
			{
				SeedShipService(dbContext);
			}
		}

		private static void SeedShipService(ShipServiceDbContext dbContext)
		{
			var refuelingService = new ShipService()
			{
				Id = Guid.Parse("330f5d70-39f1-459d-b990-6f68a083ca97"),
				Name = "RefuelingService",
				Price = 10.25
			};

			dbContext.ShipService.Add(refuelingService);

			var electricityService = new ShipService()
			{
				Id = Guid.Parse("f8a3b992-6f5c-4a32-9ac3-b62497c28d25"),
				Name = "ElectricityService",
				Price = 25.25
			};

			dbContext.ShipService.Add(electricityService);

			var loadingService = new ShipService()
			{
				Id = Guid.Parse("6d96ec17-9596-434d-a39f-3227cdbefda2"),
				Name = "LoadingService",
				Price = 15.33
			};

			dbContext.ShipService.Add(loadingService);

			var unloadingService = new ShipService()
			{
				Id = Guid.Parse("5c80d53c-91fa-4578-937d-4afb214ff960"),
				Name = "UnloadingService",
				Price = 15.34
			};

			dbContext.ShipService.Add(unloadingService);

			dbContext.SaveChanges();
		}
	}
}
