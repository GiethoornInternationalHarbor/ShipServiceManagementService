using Microsoft.AspNetCore.Mvc;
using ShipServiceManagement.Logic.Interfaces;
using ShipServiceManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipServiceManagement.App.Controllers
{
	[Route("api/shipservice")]
	public class ShipServiceController : ControllerBase
	{
		private readonly IShipServiceManager _shipServiceManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="ShipServiceController"/> class.
		/// </summary>
		/// <param name="shipServiceManager">The ship service manager.</param>
		public ShipServiceController(IShipServiceManager shipServiceManager)
		{
			_shipServiceManager = shipServiceManager;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IEnumerable<ShipService> services = await _shipServiceManager.GetShipServices();
			return Ok(services);
		}

		/// <summary>
		/// Posts the specified ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]ShipService shipService)
		{
			IActionResult response = null;

			if (shipService == null || shipService.Id == null || shipService.Id == Guid.Empty)
			{
				response = NotFound();
			}
			else
			{
				var createdShipService = await _shipServiceManager.CreateShipService(shipService);
				response = Ok(createdShipService);
			}

			return response;
		}

		/// <summary>
		/// Puts the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody]ShipService shipService)
		{
			IActionResult response = null;

			if (shipService == null)
			{
				response = NotFound();
			}
			else
			{
				var updatedShipService = await _shipServiceManager.UpdateShipService(id, shipService);
				response = Ok(updatedShipService);
			}

			return response;
		}

		/// <summary>
		/// Deletes the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			IActionResult response = null;

			if (id == null || id == Guid.Empty)
			{
				response = NotFound();
			}
			else
			{
				await _shipServiceManager.DeleteShipService(id);
				response = Ok();
			}

			return response;
		}
	}
}
