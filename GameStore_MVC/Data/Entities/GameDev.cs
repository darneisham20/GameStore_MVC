using System.ComponentModel.DataAnnotations;

namespace GameStore_MVC.Data.Entities
{
	public partial class GameDev
	{
		[Key]
		public int Id { get; set; }
		public string Developer { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string Est { get; set; } = null!;
		public List<Game> Games { get; set; } = null!;
	}
}
