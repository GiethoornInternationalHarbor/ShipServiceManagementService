using ShipServiceManagement.Models;
using System;
using System.Collections.Generic;
using ShipServiceManagement.Logic.Interfaces;
using System.Threading.Tasks;

namespace ShipServiceManagement.App.Seed
{
	public static class SeedHelper
	{
		public async static Task Seed(IShipServiceManager shipServiceManager)
		{
			var shipServices = new List<ShipService>();

			var refuelingService = new ShipService()
			{
				Id = Guid.Parse("ff9f7c8c-92b6-4863-8451-de7c94389d53"),
				Name = "RefuelingService",
				Price = 10.25
			};

			shipServices.Add(refuelingService);

			var electricityService = new ShipService()
			{
				Id = Guid.Parse("adfe1a0c-28fa-4e0e-a0c1-524bf1bb3624"),
				Name = "ElectricityService",
				Price = 25.25
			};

			shipServices.Add(electricityService);

			var loadingService = new ShipService()
			{
				Id = Guid.Parse("6d96ec17-9596-434d-a39f-3227cdbefda2"),
				Name = "LoadingService",
				Price = 15.33
			};

			shipServices.Add(loadingService);

			var unloadingService = new ShipService()
			{
				Id = Guid.Parse("5c80d53c-91fa-4578-937d-4afb214ff960"),
				Name = "UnloadingService",
				Price = 15.34
			};

			shipServices.Add(unloadingService);

			foreach (var shipService in shipServices)
			{
				await shipServiceManager.CreateShipService(shipService);
			}

			Console.WriteLine("Seed completed");
		}
	}
}
