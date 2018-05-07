using Microsoft.Extensions.DependencyInjection;

namespace ShipServiceManagement.Logic.Extensions
{
	public static class DIHelper
    {
		public static IServiceCollection AddLogic(this IServiceCollection services)
		{


			return services;
		}
    }
}
