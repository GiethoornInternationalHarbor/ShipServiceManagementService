using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipServiceManagement.Models
{
	public class ShipService
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }
	}
}
