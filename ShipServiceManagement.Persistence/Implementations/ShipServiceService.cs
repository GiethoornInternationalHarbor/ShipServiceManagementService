using ShipServiceManagement.Persistence.Interfaces;
using ShipServiceManagement.Models;
using ShipServiceManagement.Persistence.Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShipServiceManagement.Persistence.Implementations
{
	public class ShipServiceService : IShipServiceService
	{
		private readonly ShipServiceDbContext _shipServiceContext;

		public ShipServiceService(ShipServiceDbContext shipServiceContext)
		{
			_shipServiceContext = shipServiceContext;
		}

		public async Task<ShipService> AddAsync(ShipService shipService)
		{
			var shipServiceToAdd = (await _shipServiceContext.ShipService.AddAsync(shipService)).Entity;
			await _shipServiceContext.SaveChangesAsync();

			return shipServiceToAdd;
		}

		public async Task DeleteAsync(string name)
		{
			var shipServiceToDelete = new ShipService() { Name = name };
			_shipServiceContext.Entry(shipServiceToDelete).State = EntityState.Deleted;
			await _shipServiceContext.SaveChangesAsync();
		}

		public Task<ShipService> GetAsync(string name)
		{
			return _shipServiceContext.ShipService.LastOrDefaultAsync(x => x.Name == name);
		}

		public async Task<ShipService> UpdateAsync(ShipService shipService)
		{
			var updatedShipService = _shipServiceContext.ShipService.Update(shipService);
			await _shipServiceContext.SaveChangesAsync();

			return updatedShipService.Entity;
		}
	}
}
