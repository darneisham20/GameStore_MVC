using GameStore_MVC.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GameStore_MVC.Data.Entities
{
	public partial class Game
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }

		[DisplayName("Quantity in Stock")]
		public int QuantityInStock { get; set; }

        [DisplayName("Image Url")]
        public string ImageURL { get; set; } = null!;

        // ENUMS
        [DisplayName("Age Rating")]
        public AgeRating AgeRating { get; set; }

        [DisplayName("Platform")]
        public Platform Platform { get; set; }

		// GameDev FK
		public int? GameDevId { get; set; }
		[ForeignKey(nameof(GameDevId))]

        [DisplayName("Game Developer")]
        public GameDev? GameDevs { get; set; }

		public List<Order> Orders { get; set; }
	}
}
