using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

#if DEBUG
namespace ShipServiceManagement.Persistence.Database
{
	public class ShipServiceDbContextFactory : IDesignTimeDbContextFactory<ShipServiceDbContext>
	{
		public ShipServiceDbContext CreateDbContext(string[] args)
		{
			var optBuilder = new DbContextOptionsBuilder<ShipServiceDbContext>();
			optBuilder.UseSqlServer("Server=.\\SQL_2017;Database=ShipServiceManagement;Trusted_Connection=True;MultipleActiveResultSets=true");

			return new ShipServiceDbContext(optBuilder.Options);
		}
	}
}
#endif