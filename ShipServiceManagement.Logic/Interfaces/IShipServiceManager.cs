using ShipServiceManagement.Models;
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
		Task CreateShipService(ShipService shipService);

		/// <summary>
		/// Updates the ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		Task UpdateShipService(ShipService shipService);

		/// <summary>
		/// Deletes the ship service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		Task DeleteShipService(string name);
	}
}
