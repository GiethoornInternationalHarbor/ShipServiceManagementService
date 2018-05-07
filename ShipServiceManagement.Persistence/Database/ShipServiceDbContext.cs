using Microsoft.EntityFrameworkCore;
using ShipServiceManagement.Models;

namespace ShipServiceManagement.Persistence.Database
{
	public class ShipServiceDbContext : DbContext
	{
		public ShipServiceDbContext(DbContextOptions options)
			: base(options)
		{ }

		public DbSet<ShipService> ShipService { get; set; }	  
	}
}
