using System.Threading.Tasks;
using ShipServiceManagement.Logic.Interfaces;
using ShipServiceManagement.Messaging.Interfaces;
using ShipServiceManagement.Models;
using ShipServiceManagement.Persistence.Interfaces;
using ShipServiceManagement.Messaging.Extensions;

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

		public async Task CreateShipService(ShipService shipService)
		{
			await _shipServiceService.AddAsync(shipService);
			await _messagePublisher.PublishMessageAsync(MessageTypes.ServiceCreated, shipService);
		}

		public async Task DeleteShipService(string name)
		{
			await _shipServiceService.DeleteAsync(name);
			await _messagePublisher.PublishMessageAsync(MessageTypes.ServiceDeleted, name);
		}

		public async Task UpdateShipService(ShipService shipService)
		{
			await _shipServiceService.UpdateAsync(shipService);
			await _messagePublisher.PublishMessageAsync(MessageTypes.ServiceUpdated, shipService);
		}
	}
}
