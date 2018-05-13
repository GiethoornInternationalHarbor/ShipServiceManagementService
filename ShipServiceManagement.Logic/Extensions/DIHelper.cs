using Microsoft.Extensions.DependencyInjection;
using ShipServiceManagement.Logic.Implementations;
using ShipServiceManagement.Logic.Interfaces;

namespace ShipServiceManagement.Logic.Extensions
{
	public static class DIHelper
	{
		public static IServiceCollection AddLogic(this IServiceCollection services)
		{
			services.AddTransient<IShipServiceManager, ShipServiceManager>();

			return services;
		}
	}
}
