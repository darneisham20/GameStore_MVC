using System.ComponentModel.DataAnnotations;
using GameStore_MVC.Data.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore_MVC.Models.GameStoreViewModels.GameVM
{
	public class GameCreate
	{
		[Required]
		public string Title { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int QuantityInStock { get; set; }

		public string ImageURL { get; set; } = null!;

		// ENUMS
		[Required]
		public AgeRating AgeRating { get; set; }

		[Required]
		public Platform Platform { get; set; }

		public int GameDevId { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> GameOptions { get; set; } = new List<SelectListItem>();
	}
}
