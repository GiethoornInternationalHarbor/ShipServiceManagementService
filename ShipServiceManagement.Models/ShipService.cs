using System.ComponentModel.DataAnnotations;

namespace ShipServiceManagement.Models
{
	public class ShipService
	{
		[Key]
		public string Name { get; set; }

		public double Price { get; set; }
	}
}
