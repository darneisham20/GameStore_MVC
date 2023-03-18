using GameStore_MVC.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameStore_MVC.Data.Entities
{
	public class Game
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
		public string ImageURL { get; set; } = null!;

		// ENUMS
		public AgeRating AgeRating { get; set; }
		public Platform Platform { get; set; }

		// GameDev FK
		public int? GameDevId { get; set; }
		[ForeignKey(nameof(GameDevId))]
		public GameDev? GameDevs { get; set; }

		public List<Order> Orders { get; set; }
	}
}
