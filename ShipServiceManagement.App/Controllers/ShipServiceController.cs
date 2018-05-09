﻿using Microsoft.AspNetCore.Mvc;
using ShipServiceManagement.Logic.Interfaces;
using ShipServiceManagement.Models;

namespace ShipServiceManagement.App.Controllers
{
	[Route("api/shipservice")]
	public class ShipServiceController : Controller
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

		/// <summary>
		/// Posts the specified ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post([FromBody]ShipService shipService)
		{
			IActionResult response = null;

			if (shipService == null)
			{
				response = NotFound();
			}
			else
			{
				_shipServiceManager.CreateShipService(shipService);
				response = Ok();
			}

			return response;
		}

		/// <summary>
		/// Puts the specified ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		[HttpPut]
		public IActionResult Put([FromBody]ShipService shipService)
		{
			IActionResult response = null;

			if (shipService == null)
			{
				response = NotFound();
			}
			else
			{
				_shipServiceManager.UpdateShipService(shipService);
				response = Ok();
			}

			return response;
		}

		/// <summary>
		/// Deletes the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		[HttpDelete]
		public IActionResult Delete([FromBody]string name)
		{
			IActionResult response = null;

			if (string.IsNullOrEmpty(name))
			{
				response = NotFound();
			}
			else
			{
				_shipServiceManager.DeleteShipService(name);
				response = Ok();
			}

			return response;
		}
	}
}
