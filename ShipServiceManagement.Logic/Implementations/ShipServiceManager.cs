﻿using System.Threading.Tasks;
using ShipServiceManagement.Logic.Interfaces;
using ShipServiceManagement.Messaging.Interfaces;
using ShipServiceManagement.Models;
using ShipServiceManagement.Persistence.Interfaces;
using ShipServiceManagement.Messaging.Extensions;
using System;

namespace ShipServiceManagement.Logic.Implementations
{
	public class ShipServiceManager : IShipServiceManager
	{
		private readonly IShipServiceService _shipServiceService;
		private readonly IMessagePublisher _messagePublisher;

		public ShipServiceManager(IShipServiceService shipServiceService, IMessagePublisher messagePublisher)
		{
			_shipServiceService = shipServiceService;
			_messagePublisher = messagePublisher;
		}

		public async Task<ShipService> CreateShipService(ShipService shipService)
		{
			var addedShipService = await _shipServiceService.AddAsync(shipService);
			await _messagePublisher.PublishMessageAsync(MessageTypes.ServiceCreated, shipService);
			return addedShipService;
		}

		public async Task DeleteShipService(Guid id)
		{
			await _shipServiceService.DeleteAsync(id);
			await _messagePublisher.PublishMessageAsync(MessageTypes.ServiceDeleted, id);
		}

		public async Task<ShipService> UpdateShipService(ShipService shipService)
		{
			var updatedShipService = await _shipServiceService.UpdateAsync(shipService);
			await _messagePublisher.PublishMessageAsync(MessageTypes.ServiceUpdated, shipService);
			return updatedShipService;
		}
	}
}