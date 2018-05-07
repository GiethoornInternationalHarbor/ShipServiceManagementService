using Microsoft.Extensions.DependencyInjection;
using ShipServiceManagement.Messaging.Implementations;
using ShipServiceManagement.Messaging.Interfaces;

namespace ShipServiceManagement.Messaging.Extensions
{
	public static class DIHelper
	{
		public static IServiceCollection AddMessaging(this IServiceCollection services)
		{
			services.AddTransient<IMessagePublisher, RabbitMQMessagePublisher>();

			return services;
		}
	}
}
