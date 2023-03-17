using GameStore_MVC.Data.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore_MVC.Models.GameStoreViewModels.GameVM
{
	public class GameListItem
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
		public string ImageURL { get; set; } = null!;

		// ENUMS
		public AgeRating AgeRating { get; set; }
		public Platform Platform { get; set; }

		public int GameDevId { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> GameOptions { get; set; } = new List<SelectListItem>();
	}
}
