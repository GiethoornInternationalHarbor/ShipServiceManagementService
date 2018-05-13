using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShipServiceManagement.Messaging.Implementations;
using ShipServiceManagement.Messaging.Interfaces;

namespace ShipServiceManagement.Messaging.Extensions
{
	public static class DIHelper
	{
		public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IMessagePublisher, RabbitMQMessagePublisher>((provider => new RabbitMQMessagePublisher(configuration.GetSection("AMQP_URL").Value)));

			return services;
		}
	}
}
