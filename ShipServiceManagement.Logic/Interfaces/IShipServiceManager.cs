using ShipServiceManagement.Models;
using System;
using System.Threading.Tasks;

namespace ShipServiceManagement.Logic.Interfaces
{
	public interface IShipServiceManager
	{
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
		Task<ShipService> UpdateShipService(ShipService shipService);

		/// <summary>
		/// Deletes the ship service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		Task DeleteShipService(Guid id);
	}
}
