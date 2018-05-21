using ShipServiceManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipServiceManagement.Logic.Interfaces
{
	public interface IShipServiceManager
	{
		/// <summary>
		/// Gets the ship services.
		/// </summary>
		/// <returns></returns>
		Task<List<ShipService>> GetShipServices();

		/// <summary>
		/// Creates the ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		Task<ShipService> CreateShipService(ShipService shipService);

		/// <summary>
		/// Updates the ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		Task<ShipService> UpdateShipService(Guid id, ShipService shipService);

		/// <summary>
		/// Deletes the ship service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		Task DeleteShipService(Guid id);
	}
}
