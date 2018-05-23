using ShipServiceManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipServiceManagement.Persistence.Interfaces
{
	public interface IShipServiceService
	{
		/// <summary>
		/// Gets the count asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<int> GetCountAsync();

		/// <summary>
		/// Gets the asynchronous.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		Task<ShipService> GetAsync(Guid id);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		Task<ShipService> AddAsync(ShipService shipService);

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="price">The price.</param>
		/// <returns></returns>
		Task<ShipService> UpdateAsync(ShipService shipService);

		/// <summary>
		/// Deletes the asynchronous.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);

		/// <summary>
		/// Gets all shipservices.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ShipService>> GetAll();
	}
}
