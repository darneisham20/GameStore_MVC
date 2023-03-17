using System.ComponentModel.DataAnnotations;

namespace GameStore_MVC.Models.GameStoreViewModels.GameDevVM
{
	public class GameDevCreate
	{
		[Required]
		public string Developer { get; set; } = null!;

		[Required]
		public string City { get; set; } = null!;

		[Required]
		public string Country { get; set; } = null!;

		[Required]
		public string Est { get; set; } = null!;

		[Required]
		public int GameId { get; set; }
	}
}
