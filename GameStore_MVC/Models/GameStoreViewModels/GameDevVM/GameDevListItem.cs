using GameStore_MVC.Data.Entities;

namespace GameStore_MVC.Models.GameStoreViewModels.GameDevVM
{
	public class GameDevListItem
	{
		public int Id { get; set; }
		public string Developer { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string Est { get; set; } = null!;
		public List<Game> Games { get; set; } = null!;
	}
}
